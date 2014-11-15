using HeroVsRobot.DTO;
using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class WeaponService
  {
    public static Result UpgradeWeapon(string userId)
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
          var weaponImprovement = upgradeWeapon(hero, dice);
          heroContext.SaveChanges();

          var successMessage = 
            string.Format("Weapon upgrade was successful giving you an improvement of {0}!", 
              weaponImprovement);

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

    private static int upgradeWeapon(Hero hero, DiceService diceService)
    {
      var weaponImprovement = diceService.Roll(12, 2);
      hero.WeaponBonus += weaponImprovement;
      hero.Credits -= 10;
      hero.MovesRemaining -= 1;
      return weaponImprovement;
    }

  }
}