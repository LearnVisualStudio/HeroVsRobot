namespace HeroVsRobot.DTO
{
  public class BattleRound
  {
    public int RoundNumber { get; set; } 

    public int HeroDamageInflicted { get; set; }
    public int HeroHealth { get; set; }
    public int HeroHealthBeginning { get; set; }

    public int RobotDamageInflicted { get; set; }
    public int RobotHealth { get; set; }
    public int RobotHealthBeginning { get; set; }
  }
}