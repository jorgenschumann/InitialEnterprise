using System;

namespace InitialEnterprise.Infrastructure.DDD.Event
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AggregateRootId { get; set; }
        public Guid CommandId { get; set; }
        public Int64 Version { get; set; }
        public Guid UserId { get; set; }
        public String Source { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}