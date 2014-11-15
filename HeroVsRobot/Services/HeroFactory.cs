using System.Linq;
using HeroVsRobot.Models;

namespace HeroVsRobot.Services
{
  public static class HeroFactory
  {
    public static Hero GetHero(string heroId)
    {
      Hero hero;
      using (var heroContext = new HeroContext())
      {
         hero = heroContext.Heroes.Single(p => p.UserId == heroId);
      }
      return hero;
    }
  }
}