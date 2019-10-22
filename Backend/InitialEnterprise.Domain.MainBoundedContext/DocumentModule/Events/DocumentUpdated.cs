using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Events
{
    public class DocumentUpdated : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}
