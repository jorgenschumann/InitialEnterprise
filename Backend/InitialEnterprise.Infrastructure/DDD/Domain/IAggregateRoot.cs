using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Event;
using Newtonsoft.Json;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }

        Guid UserId { get; }
        
        [JsonIgnore]
        IList<IDomainEvent> Events { get; }

        void ApplyEvents(IEnumerable<IDomainEvent> events);
    }
}