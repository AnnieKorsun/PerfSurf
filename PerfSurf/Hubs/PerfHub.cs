using Microsoft.AspNet.SignalR;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Hi!");
        }
    }
}