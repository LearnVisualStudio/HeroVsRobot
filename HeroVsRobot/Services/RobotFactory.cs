using HeroVsRobot.Enums;
using HeroVsRobot.Models;

namespace HeroVsRobot.Services
{
  public static class RobotFactory
  {
    public static Robot GetRobot(RobotDifficulty difficulty, DiceService diceService)
    {
      var damageMaximum = 0;
      var healthMaximum = 0;

      switch (difficulty)
      {
        case RobotDifficulty.Difficult:
          {
            damageMaximum = 50;
            healthMaximum = 50;
            break;
          }
        case RobotDifficulty.Moderate:
          {
            damageMaximum = 35;
            healthMaximum = 35;
            break;
          }
        case RobotDifficulty.Easy:
          {
            damageMaximum = 20;
            healthMaximum = 20;
            break;
          }
      }
      var robot = new Robot
      {
        Name = "Robot",
        Difficulty = difficulty,
        Health = diceService.Roll(healthMaximum),
        DamageMaximum = diceService.Roll(damageMaximum)
      };
      return robot;
    }
  }
}