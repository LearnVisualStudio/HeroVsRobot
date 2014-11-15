using System;

namespace WebJobActivityQueueProcessor
{
  public class Activity
  {
    public string Key { get; set; }
    public string UserId { get; set; }

    public DateTime Date { get; set; }
    public EventType Event { get; set; }
    public string Message { get; set; }
  }
}