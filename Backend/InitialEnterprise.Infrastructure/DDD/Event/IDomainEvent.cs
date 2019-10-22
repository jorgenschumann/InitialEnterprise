using System;
using InitialEnterprise.Infrastructure.CQRS.Events;

namespace InitialEnterprise.Infrastructure.DDD.Event
{   
    public interface IDomainEvent : IEvent
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }
        long Version { get; set; }
        Guid UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
    }
}