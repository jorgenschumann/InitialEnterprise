using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Events
{
    public class DocumentCreated : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}
