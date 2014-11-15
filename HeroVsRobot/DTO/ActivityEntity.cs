using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace HeroVsRobot.DTO
{
  public class ActivityEntity : TableEntity
  {
    public string ActivityType { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }

    public ActivityEntity(string userName, DateTime activityDate)
    {
      PartitionKey = userName;
      RowKey = activityDate.Ticks.ToString();
    }

    public ActivityEntity()
    {
    }
  }
}