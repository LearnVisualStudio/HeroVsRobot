using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class TrainingService
  {
    public static Result Train(string userId)
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
          var trainingIncrease = performTraining(hero, dice);
          heroContext.SaveChanges();

          var successMessage = 
            string.Format("Training was successful earning you a {0} point training advantage!", 
            trainingIncrease);

          result.Message = successMessage;
          result.Hero = hero;

          ActivityService.QueueActivity(userId, EventType.Weapon, successMessage);
        }
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.Message);
        throw;
      }
      return result;
    }

    private static int performTraining(Hero hero, DiceService diceService)
    {
      var trainingImprovement = diceService.Roll(10);
      hero.TrainingLevel += trainingImprovement;
      hero.Credits -= 1;
      hero.MovesRemaining -= 1;
      return trainingImprovement;
    }

  }
}