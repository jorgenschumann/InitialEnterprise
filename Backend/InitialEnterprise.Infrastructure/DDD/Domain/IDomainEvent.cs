using System;
using InitialEnterprise.Infrastructure.CQRS.Events;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }
        int Version { get; set; }
        Guid UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
