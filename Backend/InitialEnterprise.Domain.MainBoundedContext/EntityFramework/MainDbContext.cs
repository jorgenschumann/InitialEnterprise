using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : DbContext,  IMainDbContext, IInjectableUnitOfWork
    {
        private readonly IMediator mediator;

        private MainDbContext(DbContextOptions<MainDbContext> options) : base (options) { }
               
        public MainDbContext(DbContextOptions<MainDbContext> contextOptions, IMediator mediator) : base(contextOptions)
        {
            mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this.mediator = mediator;
        }
        
        public DbSet<Currency> Currencies { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await mediator.DispatchDomainEventsAsync(this);
            
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());           
            base.OnModelCreating(modelBuilder);
        }       
    }
}
