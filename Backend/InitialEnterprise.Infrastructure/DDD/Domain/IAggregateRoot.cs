using System;
using System.Collections.Generic;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        IList<IDomainEvent> Events { get; }
        void ApplyEvents(IEnumerable<IDomainEvent> events);
    }
}
