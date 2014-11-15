using HeroVsRobot.Enums;
using System;

namespace HeroVsRobot.Models
{
  public class Activity
  {
    public string UserId { get; set; }
    public string Key { get; set; }
    public DateTime Date { get; set; }
    public EventType Event { get; set; }
    public string Message { get; set; }

    public Activity()
    {
      var ticks = DateTime.MaxValue.Ticks;
      var utcNow = DateTime.UtcNow;
      Key = string.Format("{0:D19}", ticks - utcNow.Ticks);
    }
  }
}