using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Events
{
    public class PersonUpdatedByNewEmailAddressDomainEvent : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}
