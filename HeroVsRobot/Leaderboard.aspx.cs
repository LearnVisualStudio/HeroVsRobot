using HeroVsRobot.Services;
using System;
using System.Web.UI;

namespace HeroVsRobot
{
  public partial class Leaderboard : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      generateLeaderboard();
    }

    private void generateLeaderboard()
    {
      var heros = LeaderboardService.GenerateLeaderboard();
      var leaderboard = "<table class='table table-striped'>";
      leaderboard += "<tr><th>Place</th><th>Credits</th><th>Hero</th></tr>";
      var rank = 0;
      foreach (var hero in heros)
      {
        rank++;
        leaderboard += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", 
          rank, 
          hero.Credits, 
          hero.Name);
      }
      leaderboard += "</table>";
      leaderboardLiteral.Text = leaderboard;
    }
  }
}