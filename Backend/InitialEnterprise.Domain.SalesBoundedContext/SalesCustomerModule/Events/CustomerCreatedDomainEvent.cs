using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Events
{
    public class CustomerCreatedDomainEvent : DomainEvent
    {
        public string CommandJson { get; set; }
    }
}
