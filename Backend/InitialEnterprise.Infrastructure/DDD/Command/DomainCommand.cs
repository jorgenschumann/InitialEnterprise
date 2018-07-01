﻿using System;

namespace InitialEnterprise.Infrastructure.DDD.Command
{
    public class DomainCommand : IDomainCommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AggregateRootId { get; set; }
        public Guid UserId { get; set; }
        public string Source { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}