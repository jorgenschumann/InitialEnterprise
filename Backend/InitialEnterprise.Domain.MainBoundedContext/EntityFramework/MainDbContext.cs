using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : DbContext, IUnitOfWork, IMainDbContext, IInjectableUnitOfWork
    {
        public MainDbContext(DbContextOptions<MainDbContext> contextOptions): base(contextOptions)
        {         
        }
        
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());
            //modelBuilder.Entity<Currency>().HasData(CurrenciesTestData().ToArray());
            base.OnModelCreating(modelBuilder);
        }
    }

    public interface IMainDbContext
    {
        DbSet<Currency> Currencies { get; set; }
    }
}
