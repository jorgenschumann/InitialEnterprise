using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        IList<IDomainEvent> Events { get; }
        void ApplyEvents(IEnumerable<IDomainEvent> events);
    }
}
