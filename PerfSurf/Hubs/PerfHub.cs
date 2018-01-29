using Microsoft.AspNet.SignalR;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.NewMessage(Context.User.Identity.Name + " says " + message);
        }
    }
}