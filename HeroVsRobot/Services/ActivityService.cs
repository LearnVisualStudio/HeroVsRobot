using HeroVsRobot.Enums;
using HeroVsRobot.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

// The activity service takes the player's last action ...
// what did they do? when did they do it? what was the result?
// and creates a new instance of the Activity class with all
// of that information.  Then, it serializes it into JSON 
// and puts it on the "activity" queue.

// The WebJob "WebJobActivityQueueProcessor" runs continuously.
// When a new queued message arrives, it takes it off the queue 
// and puts it into the Azure Storage Table "activityHistory".

// When the user goes to the CommandCenter.aspx they will see
// rows from the activityHistory table.

namespace HeroVsRobot.Services
{
  public static class ActivityService
  {

    public static void QueueActivity(
      string userId, 
      EventType eventType, 
      string message)
    {
      try
      {
        var cloudStorageAccount = 
          CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

        var queueReference = 
          cloudStorageAccount.CreateCloudQueueClient()
            .GetQueueReference("activity");

        queueReference.CreateIfNotExists();

        var activity = new Activity
        {
          UserId = userId,
          Event = eventType,
          Date = DateTime.Now,
          Message = message
        };

        var cloudQueueMessage = 
          new CloudQueueMessage(JsonConvert.SerializeObject(activity));

        queueReference.AddMessage(cloudQueueMessage);
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.Message);
      }
    }
  }
}