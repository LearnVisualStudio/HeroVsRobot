using HeroVsRobot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HeroVsRobot.Services
{
  public static class LeaderboardService
  {

    public static IEnumerable<Hero> GenerateLeaderboard()
    {
      IEnumerable<Hero> list;
      try
      {
        using (var heroContext = new HeroContext())
        {
          var heros =
              from p in heroContext.Heroes.Take(10)
              orderby p.Credits descending
              select p;
          list = heros.ToList();
        }
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.Message);
        throw;
      }
      return list;
    }
  }
}