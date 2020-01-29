using InitialEnterprise.Domain.SalesBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.EntityFramework
{
    public class SalesDbContext : DbContext, ISalesDbContext
    {
        public SalesDbContext() : this(null)
        {
        }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }


        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
                      
            base.OnModelCreating(modelBuilder);           
        }
    }
}