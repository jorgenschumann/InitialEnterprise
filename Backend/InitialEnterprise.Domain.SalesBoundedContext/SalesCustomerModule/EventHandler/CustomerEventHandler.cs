using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Events;
using InitialEnterprise.Infrastructure.CQRS.Events;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.EventHandler
{
    public class CustomerEventHandler :
        IEventHandlerAsync<CustomerCreatedDomainEvent>

    {
        public Task HandleAsync(CustomerCreatedDomainEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
