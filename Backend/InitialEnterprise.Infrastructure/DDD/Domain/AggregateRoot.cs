using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        protected AggregateRoot()
        {
            Id = Guid.Empty;
        }

        protected AggregateRoot(Guid id)
        {
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }
            Id = id;
        }

        public Guid Id { get; protected set; }

        public IList<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();

        public void ApplyEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
                Events.Add(@event);
            //this.AsDynamic().Apply(@event);//TODO:ReflectionMagic
        }

        protected void AddEvent(IDomainEvent @event)
        {
            Events.Add(@event);
            {
                //this.AsDynamic().Apply(@event); //TODO:ReflectionMagic
            }
        }
    }
}