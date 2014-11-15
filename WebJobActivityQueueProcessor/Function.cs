using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.IO;

namespace WebJobActivityQueueProcessor
{
  public class Function
  {
    public static void ProcessActivityQueue([QueueTrigger("activity")] Activity activity, TextWriter log)
    {
      var cloudStorageAccount = 
        CloudStorageAccount.Parse(
          CloudConfigurationManager
            .GetSetting("StorageConnectionString"));

      var tableReference = 
          cloudStorageAccount
            .CreateCloudTableClient()
              .GetTableReference("activityHistory");

      tableReference.CreateIfNotExists();

      var activityEntity = new ActivityEntity(activity.UserId, activity.Key)
      {
        ActivityType = activity.Event.ToString(),
        Date = activity.Date,
        Message = activity.Message
      };

      var tableOperation = TableOperation.Insert(activityEntity);
      try
      {
        tableReference.Execute(tableOperation);
      }
      catch (Exception exception)
      {
        log.WriteLine(exception.Message);
      }
    }
  }
}