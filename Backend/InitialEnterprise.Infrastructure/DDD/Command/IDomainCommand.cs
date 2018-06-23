using System;
using InitialEnterprise.Infrastructure.CQRS.Command;

namespace InitialEnterprise.Infrastructure.DDD.Command
{
    public interface IDomainCommand : ICommand
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
    }
}