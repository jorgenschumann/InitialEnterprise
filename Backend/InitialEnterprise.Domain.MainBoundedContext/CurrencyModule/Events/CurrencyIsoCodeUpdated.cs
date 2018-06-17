using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events
{
    public class CurrencyIsoCodeUpdated : DomainEvent
    {
        public string IsoCode { get; set; }
    }
}