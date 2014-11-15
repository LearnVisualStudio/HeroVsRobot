using System;

// This is the only non-Static service in the application
// due to the way the Random class is seeded and how it
// generates the next "random" number.  Keeping it alive
// for all dice roll needs keeps the "random" numbers from
// being the same.
// For more information on how the Random class works:
// http://csharpindepth.com/Articles/Chapter12/Random.aspx

namespace HeroVsRobot.Services
{
  public class DiceService
  {
    private readonly Random _random = new Random();

    public int Roll(int maximum)
    {
      return _random.Next(maximum + 1);
    }

    public int Roll(int maximum, int minimum)
    {
      return _random.Next(minimum, maximum + 1);
    }
  }
}