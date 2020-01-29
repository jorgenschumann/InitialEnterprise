using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> Update(Customer customer);

        Task<Customer> Insert(Customer customer);

        Task<IEnumerable<Customer>> Query(CustomerQuery query);

        Task<IEnumerable<Customer>> Query(CustomerSeachQuery query);

        Task<Customer> Query(Guid customerId);
    }
}