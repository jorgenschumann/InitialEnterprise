using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events
{
    public class CurrencyRateUpdated : DomainEvent
    {
        public decimal Rate { get; set; }
    }
}