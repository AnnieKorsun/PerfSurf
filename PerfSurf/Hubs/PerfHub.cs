using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using PerfSurf.Counters;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerformanceCounterService();
                while (true)
                {
                    var results = perfService.GetResults();
                    Clients.All.NewCounters(results);
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            Clients.All.NewMessage(Context.User.Identity.Name + " says " + message);
        }
    }
}