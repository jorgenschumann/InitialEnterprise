using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.QueryHandler
{
    public class CustomerQueryHandlerAsync :
        IQueryHandlerAsync<CustomerQuery, Customer>,
        IQueryHandlerAsync<CustomerSeachQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerQueryHandlerAsync(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Retrieve(CustomerQuery query)
        {
            return await customerRepository.Query(query.Id);
        }

        public async Task<IEnumerable<Customer>> Retrieve(CustomerSeachQuery query)
        {
            return await customerRepository.Query(query);
        }       
    }
}
