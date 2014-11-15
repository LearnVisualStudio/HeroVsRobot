using Microsoft.Azure.WebJobs;

namespace WebJobActivityQueueProcessor
{
  // To learn more about Microsoft Azure WebJobs, please see http://go.microsoft.com/fwlink/?LinkID=401557
  class Program
  {
    static void Main()
    {
      JobHost host = new JobHost();
      host.RunAndBlock();
    }
  }
}
