using HeroVsRobot.Enums;
using HeroVsRobot.Services;
using System;

namespace HeroVsRobot.Models
{
  public class Robot
  {
    public string Name { get; set; }
    public RobotDifficulty Difficulty { get; set; }
    public int Health { get; set; }
    public int ArmorRating { get; set; }
    public int DamageMaximum { get; set; }

    public Robot()
    {
      ArmorRating = 0;
      DamageMaximum = 20;
    }

    public int Attack(Hero hero, DiceService diceService)
    {
      var damageMaximum = DamageMaximum - hero.ArmorBonus;
      damageMaximum = (damageMaximum > 10 ? damageMaximum : 10);
      return diceService.Roll(damageMaximum);
    }

    public int Defend(int damage)
    {
      var damageInflicted = Math.Abs(ArmorRating - damage);
      Health -= damageInflicted;
      return damageInflicted;
    }
  }
}