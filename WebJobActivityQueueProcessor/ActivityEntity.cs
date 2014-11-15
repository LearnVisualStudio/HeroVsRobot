using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebJobActivityQueueProcessor
{
  public class ActivityEntity : TableEntity
  {
    public string ActivityType { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }

    public ActivityEntity(string userId, string key)
    {
      PartitionKey = userId;
      RowKey = key;
    }
  }
}