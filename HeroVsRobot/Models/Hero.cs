using HeroVsRobot.Enums;
using HeroVsRobot.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroVsRobot.Models
{
  [Table("Heroes")]
  public class Hero
  {
    private const int BaseDamage = 20;

    private const int DifficultRobotMaxCredits = 50;
    private const int ModerateRobotMaxCredits = 20;
    private const int EasyRobotMaxCredits = 10;


    [Key]
    public string UserId { get; set; }

    public string Name { get; set; }
    public int MovesRemaining { get; set; }
    public int Credits { get; set; }
    public int Health { get; set; }

    public int ArmorBonus { get; set; }
    public int ArmorRating { get; set; }
    public int DamageMaximum { get; set; }

    public int Wins { get; set; }
    public int Losses { get; set; }

    public int TrainingLevel { get; set; }
    public int WeaponBonus { get; set; }

    public Hero()
    {
      ArmorRating = ArmorBonus;
      DamageMaximum = BaseDamage + WeaponBonus + TrainingLevel;
    }

    public int Attack(DiceService diceService)
    {
      return diceService.Roll(DamageMaximum);
    }

    public int AwardBonusMoves(DiceService diceService, RobotDifficulty difficulty)
    {
      if (difficulty != RobotDifficulty.Difficult) return 0; 

      var bonusMoves = diceService.Roll(3);
      MovesRemaining = MovesRemaining + bonusMoves;
      return bonusMoves;
    }

    public int CollectCredits(DiceService diceService, RobotDifficulty difficulty)
    {
      var maxCredits = 0;
      switch (difficulty)
      {
        case RobotDifficulty.Difficult:
          {
            maxCredits = DifficultRobotMaxCredits;
            break;
          }
        case RobotDifficulty.Moderate:
          {
            maxCredits = ModerateRobotMaxCredits;
            break;
          }
        case RobotDifficulty.Easy:
          {
            maxCredits = EasyRobotMaxCredits;
            break;
          }
      }
      var creditsEarned = diceService.Roll(maxCredits);
      Credits += creditsEarned;
      return creditsEarned;
    }

    public int Defend(int damage)
    {
      var maxDamage = Math.Abs(ArmorRating - damage);
      Health = Health - maxDamage;
      return maxDamage;
    }
  }
}