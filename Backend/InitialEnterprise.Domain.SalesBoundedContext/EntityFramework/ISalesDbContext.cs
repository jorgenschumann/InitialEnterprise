using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


namespace InitialEnterprise.Domain.SalesBoundedContext.EntityFramework
{
    public interface ISalesDbContext : IUnitOfWork
    {
        DbSet<Customer> Customer { get; set; }    
    }  
}