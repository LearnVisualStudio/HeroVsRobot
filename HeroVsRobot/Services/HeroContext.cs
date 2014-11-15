using System.Data.Entity;
using HeroVsRobot.Models;

namespace HeroVsRobot.Services
{
  public class HeroContext : DbContext
  {
    public DbSet<Hero> Heroes { get; set; }

    public HeroContext()
      : base("name=DefaultConnection")
    {
    }
  }
}