using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Events
{
    public class PersonCreatedDomainEvent : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}
