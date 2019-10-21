using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Events
{
    public class PersonCreditCardUpdateDomainEvent : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}