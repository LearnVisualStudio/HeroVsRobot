using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class MedicBayService
  {
    public static Result VisitMedicBay(string userId)
    {
      var result = new Result();
      try
      {
        using (var heroContext = new HeroContext())
        {
          var hero = heroContext.Heroes.Single(p => p.UserId == userId);

          string validationMessage;
          if (!ValidationService.Validate(hero, 1, out validationMessage))
          {
            throw new Exception(validationMessage);
          }

          var dice = new DiceService();
          var healthRestored = restoreHealth(hero, dice);
          heroContext.SaveChanges();

          var successMessage = string.Format("The Medic Bay restored {0} health!", healthRestored);
          result.Message = successMessage;
          result.Hero = hero;

          ActivityService.QueueActivity(userId, EventType.Medic, successMessage);
        }
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.Message);
        throw;
      }
      return result;
    }

    private static int restoreHealth(Hero hero, DiceService diceService)
    {
      var healthRestored = diceService.Roll(20, 5);
      hero.Credits -= 1;
      hero.Health += healthRestored;
      hero.MovesRemaining -= 1;
      return healthRestored;
    }

  }
}