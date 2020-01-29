using InitialEnterprise.Domain.SalesBoundedContext.EntityFramework;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDbContext context;
     
        public CustomerRepository(SalesDbContext context)
        {
            this.context = context;           
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public async Task<Customer> Insert(Customer customer)
        {
            var added = await context.Customer.AddAsync(customer);
            await context.SaveEntitiesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<Customer>> Query(CustomerQuery query)
        {
            return await context.Customer.ToListAsync();
        }

        public async Task<Customer> Query(Guid customerId)
        {
                return await context
                   .Customer
                   //.Include(p => p.SalesOrderHeader)
                   .SingleOrDefaultAsync(p => p.Id == customerId);
            
        }

        public async Task<IEnumerable<Customer>> Query(CustomerSeachQuery query)
        {
            return await context.Customer.ToListAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            var updated = context.Customer.Update(customer);
            await context.SaveEntitiesAsync();
            return updated.Entity;
        }
    }
}