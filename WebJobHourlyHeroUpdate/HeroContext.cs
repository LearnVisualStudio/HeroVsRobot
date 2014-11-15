using System.Data.Entity;

namespace WebJobHourlyHeroUpdate
{
  public class HeroContext : DbContext
  {
    public virtual DbSet<Hero> Heroes { get; set; }

    public HeroContext()
      : base("name=DefaultConnection")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}