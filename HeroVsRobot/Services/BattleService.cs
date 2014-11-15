using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class BattleService
  {
    public static BattleResult PerformBattle(string userId, RobotDifficulty difficulty)
    {
      BattleResult battleResult;
      try
      {
        using (var heroContext = new HeroContext())
        {
          string validationMessage;
          var hero = heroContext.Heroes.Single(p => p.UserId == userId);
          if (!ValidationService.Validate(hero, 0, out validationMessage))
          {
            throw new Exception(validationMessage);
          }
          
          var dice = new DiceService();
          var robot = RobotFactory.GetRobot(difficulty, dice);

          battleResult = performBattle(hero, robot, dice);
          heroContext.SaveChanges();
        }
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.Message);
        throw;
      }
      return battleResult;
    }

    internal static void RecordBattle(string userId, string resultMessage)
    {
      ActivityService.QueueActivity(userId, EventType.Battle, resultMessage);
    }

    private static BattleResult performBattle(
      Hero hero, 
      Robot robot, 
      DiceService diceService)
    {
      var battleResult = new BattleResult();
      var round = 0;
      while (hero.Health > 0 && robot.Health > 0)
      {
        var battleRound = new BattleRound();

        round++;
        battleRound.RoundNumber = round;

        battleRound.RobotHealthBeginning = robot.Health;
        battleRound.HeroDamageInflicted = robot.Defend(hero.Attack(diceService));
        battleRound.RobotHealth = robot.Health;

        battleRound.HeroHealthBeginning = hero.Health;
        battleRound.RobotDamageInflicted = hero.Defend(robot.Attack(hero, diceService));
        battleRound.HeroHealth = hero.Health;

        battleResult.BattleRounds.Add(battleRound);
      }
      if (hero.Health > 0)
      {
        hero.MovesRemaining--;
        hero.Wins++;
        hero.Health = hero.Health;
        battleResult.CreditsEarned =
          hero.CollectCredits(diceService, robot.Difficulty);

        battleResult.BonusMovesAwarded =
          hero.AwardBonusMoves(diceService, robot.Difficulty);
      }
      else
      {
        hero.MovesRemaining = 0;
        hero.Losses--;
        hero.Health = 0;
      }
      battleResult.Hero = hero;
      battleResult.Robot = robot;
      return battleResult;
    }
  }
}