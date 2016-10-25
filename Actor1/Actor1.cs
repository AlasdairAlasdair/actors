using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using Actor1.Interfaces;

namespace Actor1
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class Actor1 : Actor, IActor1
    {
        private readonly ActorService _actorService;
        private readonly ActorId _actorId;

        public Actor1(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            _actorService = actorService;
            _actorId = actorId;
        }

        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            return Task.FromResult<object>(null);
        }

        Task IActor1.StartJob()
        {
            var actorId = _actorId.GetStringId();
            ActorEventSource.Current.ActorMessage(this, $"{actorId} starting a job.");
            Thread.Sleep(5000);
            ActorEventSource.Current.ActorMessage(this, $"{actorId} finished a job.");

            return Task.FromResult<object>(null);
        }
    }
}
