using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Actor1.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var appName = "fabric:/AliTestActors";
            
            while (true)
            {
                var actorId = ActorId.CreateRandom();
                var actor = ActorProxy.Create<IActor1>(actorId, appName);
                Console.WriteLine($"Starting job on actor {actorId}.");
                actor.StartJob();
                Thread.Sleep(1000);
            }
        }
    }
}
