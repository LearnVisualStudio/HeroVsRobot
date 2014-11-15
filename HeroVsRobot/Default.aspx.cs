using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using HeroVsRobot.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI;

namespace HeroVsRobot
{
  public partial class _Default : Page
  {
    private string _userId;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Context.User.Identity.IsAuthenticated)
      {
        showPanels(false);
      }
      else
      {
        _userId = User.Identity.GetUserId();
        if (!Page.IsPostBack)
        {
          updateStatistics(HeroFactory.GetHero(_userId));
        }
        showPanels(true);
        var item = Request.QueryString["action"];

        if (item == null) return;
        
        switch (item)
        {
          case "large":
          {
            fight(RobotDifficulty.Difficult);
            return;
          }
          case "medium":
          {
            fight(RobotDifficulty.Moderate);
            return;
          }
          case "small":
          {
            fight(RobotDifficulty.Easy);
            return;
          }
          case "lab":
          {
            lab();
            return;
          }
          case "port":
          {
            break;
          }
          case "armory":
          {
            armory();
            return;
          }
          case "medic":
          {
            medic();
            return;
          }
          case "command":
          {
            commandCenter();
            return;
          }
          default:
          {
            return;
          }
        }
      }
    }

    #region Helper Methods

    private void showPanels(bool show)
    {
      playerPanel.Visible = show;
      surfacePanel.Visible = show;
      visitorPanel.Visible = !show;
      introPanel.Visible = !show;
    }

    private void updateStatistics(Hero hero)
    {
      heroLiteral.Text = hero.Name;
      healthLiteral.Text = hero.Health.ToString();
      winsLiteral.Text = hero.Wins.ToString();
      lossesLiteral.Text = hero.Losses.ToString();
      movesLiteral.Text = hero.MovesRemaining.ToString();
      trainingLiteral.Text = hero.TrainingLevel.ToString();
      goldLiteral.Text = hero.Credits.ToString();
      WeaponLiteral.Text = hero.WeaponBonus.ToString();
      armorLiteral.Text = hero.ArmorBonus.ToString();
    }

    private static string formatErrorMessage(string message)
    {
      return string.Format("<p class='text-danger'>{0}</p>", message);
    }


    #endregion


    #region Calls Into Domain Layer

    private void train()
    {
      try
      {
        var result = TrainingService.Train(_userId);
        resultLabel.Text = result.Message;
        updateStatistics(result.Hero);
      }
      catch (Exception exception)
      {
        resultLabel.Text = formatErrorMessage(exception.Message);
      }
    }

    private void armory()
    {
      try
      {
        var result = WeaponService.UpgradeWeapon(_userId);
        resultLabel.Text = result.Message;
        updateStatistics(result.Hero);
      }
      catch (Exception exception)
      {
        resultLabel.Text = formatErrorMessage(exception.Message);
      }
    }

    private void medic()
    {
      try
      {
        var result = MedicBayService.VisitMedicBay(_userId);
        resultLabel.Text = result.Message;
        updateStatistics(result.Hero);
      }
      catch (Exception exception)
      {
        resultLabel.Text = formatErrorMessage(exception.Message);
      }
    }

    private void lab()
    {
      try
      {
        var result = ArmorService.PurchaseArmor(_userId);
        resultLabel.Text = result.Message;
        updateStatistics(result.Hero);
      }
      catch (Exception exception)
      {
        resultLabel.Text = formatErrorMessage(exception.Message);
      }
    }

    private void commandCenter()
    {
      Response.Redirect("CommandCenter.aspx");
    }

    private void fight(RobotDifficulty difficulty)
    {
      try
      {
        var battleResult = BattleService.PerformBattle(_userId, difficulty);
        var str = formatBattleResult(battleResult);
        resultLabel.Text = str;
        BattleService.RecordBattle(_userId, str);
        updateStatistics(battleResult.Hero);
      }
      catch (Exception exception)
      {
        resultLabel.Text = formatErrorMessage(exception.Message);
      }
    }


    #endregion


    #region Button_Click Event Handlers

    protected void TrainButton_Click(object sender, EventArgs e)
    {
      train();
    }

    protected void UpgradeArmor_Click(object sender, EventArgs e)
    {
      lab();
    }

    protected void UpgradeWeapon_Click(object sender, EventArgs e)
    {
      armory();
    }

    protected void MedicBayButton_Click(object sender, EventArgs e)
    {
      medic();
    }

    protected void CommandCenterButton_Click(object sender, EventArgs e)
    {
      commandCenter();
    }

    protected void NormalRobotButton_Click(object sender, EventArgs e)
    {
      fight(RobotDifficulty.Moderate);
    }

    protected void DifficultRobotButton_Click(object sender, EventArgs e)
    {
      fight(RobotDifficulty.Difficult);
    }

    protected void EasyRobotButton_Click(object sender, EventArgs e)
    {
      fight(RobotDifficulty.Easy);
    }

    #endregion


    #region Battle Related Helper Methods 

    private static string formatBattleResult(BattleResult battleResult)
    {
      string result;

      var robotName = battleResult.Robot.Name;
      var heroName = battleResult.Hero.Name;

      var progressMessage = "<h4>Battle Progress:</h4>";
      foreach (var battleRound in battleResult.BattleRounds)
      {
        if (battleRound.HeroHealth <= 20)
        {
          progressMessage += (battleRound.HeroHealth <= 0
            ? string.Format("<div class='bs-callout bs-callout-danger'><h4>Round {0} ...</h4>",
                battleRound.RoundNumber)
            : string.Format("<div class='bs-callout bs-callout-warning'><h4>Round {0} ...</h4>",
                battleRound.RoundNumber));
        }
        else
        {
          progressMessage += string.Format("<div class='bs-callout bs-callout-info'><h4>Round {0} ...</h4>",
            battleRound.RoundNumber);
        }

        var robotHealth = (battleRound.RobotHealth > 0 ? battleRound.RobotHealth : 0);
        var heroHealth = (battleRound.HeroHealth > 0 ? battleRound.HeroHealth : 0);

        var heroDamageInflicted = battleRound.HeroDamageInflicted;

        progressMessage += string.Format("<p>{0} inflicted {1} damage on {2} reducing {2}'s health to {3}.</p>",
          robotName,
          heroDamageInflicted,
          robotName,
          robotHealth);

        var robotDamageInflicted = battleRound.RobotDamageInflicted;

        progressMessage += string.Format("<p>{0} inflicted {1} damage on {2} reducing {2}'s health to {3}.</p>",
          heroName,
          robotDamageInflicted,
          heroName,
          heroHealth);
        progressMessage += "</div>";
      }


      if (battleResult.Hero.Health > 0)
      {
        result = string.Format("<p class='text-success'>Awesome! {0} defeats {1}!</p>",
          heroName,
          robotName);

        result += string.Format("<p class='text-success'>Earned {0} credits!</p>",
          battleResult.CreditsEarned);

        if (battleResult.BonusMovesAwarded > 0)
        {
          result += string.Format("<p class='text-success'>w00t! You earned {0} bonus moves!</p>",
            battleResult.BonusMovesAwarded);
        }
        if (battleResult.Hero.Health <= 20)
        {
          result += string.Format("<p class='text-warning'>Be careful! Your hero only has {0} health left!</p>",
            battleResult.Hero.Health);
        }
      }
      else
      {
        result = (battleResult.Robot.Health > 0
          ? string.Format("<p class='text-danger'>Oh no! {0} defeats {1}!</p>",
            robotName,
            heroName)
          : string.Format("<p class='text-danger'>Oh no! Both {0} and {1} were knocked out.",
            heroName,
            robotName));
      }
      return result + progressMessage;
    }

    #endregion

  }
}