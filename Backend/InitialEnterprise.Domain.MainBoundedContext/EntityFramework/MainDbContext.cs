using System.Threading;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : DbContext, IMainDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}