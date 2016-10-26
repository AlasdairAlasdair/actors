using Microsoft.AspNetCore.SignalR;

namespace WebServer.Hubs
{
    public class JobHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}
