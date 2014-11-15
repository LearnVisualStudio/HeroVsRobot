using System;

namespace WebJobHourlyHeroUpdate
{
  // To learn more about Microsoft Azure WebJobs, please see http://go.microsoft.com/fwlink/?LinkID=401557
  class Program
  {
    static void Main()
    {
      int resultCount;

      using (var heroContext = new HeroContext())
      {
        foreach (var hero in heroContext.Heroes)
        {
          hero.TrainingLevel = 1;
          hero.MovesRemaining = 25;
          hero.Health = 50;
        }
        resultCount = heroContext.SaveChanges();
      }

#if DEBUG

      Console.WriteLine("{0} heros updated ...", resultCount);
      Console.ReadLine();

#endif

    }
  }
}
