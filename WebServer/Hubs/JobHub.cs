using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace WebServer.Hubs
{
    public class JobHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);

            var appName = "fabric:/AliTestActors";
            var actorId = ActorId.CreateRandom();
            var actor = ActorProxy.Create<IReportingActor>(actorId, appName);
            actor.SendMessage(name);
        }
    }

    public class ReportingActor : Actor, IReportingActor
    {
        public ReportingActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        public Task SendMessage(string id)
        {
            return Task.FromResult<object>(null);
        }
    }
}
