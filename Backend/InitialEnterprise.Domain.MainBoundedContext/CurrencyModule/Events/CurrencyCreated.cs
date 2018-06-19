using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events
{
    public class CurrencyCreated : DomainEvent
    {
        public string Name { get; set; }
    }
}