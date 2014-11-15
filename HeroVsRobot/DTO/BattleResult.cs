using HeroVsRobot.Models;
using System.Collections.Generic;

namespace HeroVsRobot.DTO
{
  public class BattleResult
  {
    public Hero Hero;
    public Robot Robot;
    public List<BattleRound> BattleRounds { get; private set; }
    public int BonusMovesAwarded { get; set; }
    public int CreditsEarned { get; set; }

    public BattleResult()
    {
      BattleRounds = new List<BattleRound>();
    }
  }
}