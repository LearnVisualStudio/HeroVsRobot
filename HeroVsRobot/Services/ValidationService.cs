using HeroVsRobot.Models;

namespace HeroVsRobot.Services
{
  public static class ValidationService
  {
    public static bool Validate(Hero hero, int minimumGoldRequired, out string failureMessage)
    {
      failureMessage = "";
      if (hero.MovesRemaining <= 0)
      {
        failureMessage = "Not enough moves remaining.  You must wait until the top of the hour.";
        return false;
      }
      if (hero.Credits >= minimumGoldRequired)
      {
        return true;
      }
      failureMessage = "<p class='text-danger'>Not enough Credits to perform action.</p>";
      return false;
    }
  }
}