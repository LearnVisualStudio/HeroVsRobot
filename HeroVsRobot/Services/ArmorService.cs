using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class ArmorService
  {
    public static Result PurchaseArmor(string userId)
    {
      var result = new Result();
      try
      {
        using (var heroContext = new HeroContext())
        {
          var hero = heroContext.Heroes.Single(p => p.UserId == userId);

          string validationMessage;
          if (!ValidationService.Validate(hero, 10, out validationMessage))
          {
            throw new Exception(validationMessage);
          }
          var dice = new DiceService();
          var armorImprovement = improveArmor(hero, dice);
          
          heroContext.SaveChanges();

          var successMessage = string.Format(
            "Armor upgrade was successful giving you an improvement of {0}!", 
            armorImprovement);

          result.Message = successMessage;
          result.Hero = hero;

          ActivityService.QueueActivity(userId, EventType.Armor, successMessage);
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError(ex.Message);
        throw new Exception(ex.Message);
      }
      return result;
    }

    private static int improveArmor(Hero hero, DiceService diceService)
    {
      var armorImprovement = diceService.Roll(12, 2);
      hero.ArmorBonus += armorImprovement;
      hero.Credits -= 10;
      hero.MovesRemaining -= 1;
      return armorImprovement;
    }

  }
}