using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events
{
    public class CurrencyUpdated : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}