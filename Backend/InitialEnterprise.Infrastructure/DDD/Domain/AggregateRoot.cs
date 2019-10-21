using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Event;
using Newtonsoft.Json;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public class AggregateRoot : IAggregateRoot
    {
        protected AggregateRoot()
        {
            Id = Guid.Empty;
        }

        protected AggregateRoot(Guid id , Guid userId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;           

            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;           
        }

        [JsonProperty]
        public Guid Id { get; protected set; }

        public IList<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();

        [JsonProperty]
        public Guid UserId { get; protected set; }

        public void ApplyEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                Events.Add(@event);               
            }
        }

        protected void AddEvent(IDomainEvent @event)
        {
            Events.Add(@event);            
        }
    }
}