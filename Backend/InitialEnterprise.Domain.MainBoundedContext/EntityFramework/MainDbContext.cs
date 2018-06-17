using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : DbContext,  IMainDbContext//, IInjectable
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base (options) { }
           
        public DbSet<Currency> Currencies { get; set; }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());           
            base.OnModelCreating(modelBuilder);
        }       
    }
}
