﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Infrastructure.DDD.Event
{
    public interface IEventStore
    {
        Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot;
        
        Task<IEnumerable<DomainEvent>> GetEventsAsync(Guid aggregateId);
    }
}
