using System.ComponentModel.DataAnnotations;

namespace WebJobHourlyHeroUpdate
{
  public class Hero
  {
    [Key]
    public string UserId { get; set; }
    public string Name { get; set; }

    public int ArmorBonus { get; set; }
    public int ArmorRating { get; set; }
    public int Credits { get; set; }
    public int DamageMaximum { get; set; }
    public int Health { get; set; }
    public int Losses { get; set; }
    public int MovesRemaining { get; set; }
    public int TrainingLevel { get; set; }
    public int WeaponBonus { get; set; }
    public int Wins { get; set; }

  }
}