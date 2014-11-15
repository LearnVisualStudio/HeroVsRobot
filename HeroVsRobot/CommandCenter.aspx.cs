using HeroVsRobot.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Linq;
using System.Web.UI;

namespace HeroVsRobot
{
  public partial class CommandCenter : Page
  {
    private string _userId;
    protected string Time { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
      Time = string.Format("{0:MM/dd/yy h:mm:ss tt}", DateTime.UtcNow);

      if (!Context.User.Identity.IsAuthenticated) return;

      _userId = User.Identity.GetUserId();
      var cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
      var tableReference = cloudStorageAccount.CreateCloudTableClient().GetTableReference("activityHistory");
      
      // This will require a little explanation. In Azure Table Storage, there's no
      // way to "order" by a time field. However, someone discovered a hack by which
      // you can use the end-of-time ticks minum right-now-ticks to get your 
      // rows ordered by time.

      var ticks = DateTime.MaxValue.Ticks;
      var utcNow = DateTime.UtcNow;
      var orderingTime = string.Format("{0:D19}", ticks - utcNow.Ticks);
        
      // TODO: This probably belongs in a service:

      var activityEntities = (
        from g in tableReference.CreateQuery<ActivityEntity>()
        where (g.PartitionKey == _userId) && string.Compare(g.RowKey, orderingTime, StringComparison.Ordinal) > 0
        select g).Take<ActivityEntity>(10);
        
      // Now that we have the rows, format as a table fore display.

      var tableMarkup = "<table class='table table-striped'>";
      tableMarkup = string.Concat(tableMarkup, "<tr><th>Activity</th><th>Date</th><th>Description</th></tr>");

      foreach (var activityEntity in activityEntities)
      {
        tableMarkup = string.Concat(
          tableMarkup, 
          string.Format("<tr><td>{0}</td><td>{1:MM/dd/yy h:mm:ss tt}</td><td>{2}</td></tr>", 
            activityEntity.ActivityType, 
            activityEntity.Date, 
            activityEntity.Message));
      }
      tableMarkup = string.Concat(tableMarkup, "</table>");

      historyLiteral.Text = tableMarkup;
    }
  }
}