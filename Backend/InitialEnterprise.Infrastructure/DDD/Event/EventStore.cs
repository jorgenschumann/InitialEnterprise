using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Infrastructure.DDD.Event
{
    public class EventStore : IEventStore, IInjectable
    {
        public async Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
            await Task.Run(() => { });
        }

        public async Task<IEnumerable<DomainEvent>> GetEventsAsync(Guid aggregateId)
        {
            return await Task.Run(() => { return new List<DomainEvent>(); });
        }
    }
}