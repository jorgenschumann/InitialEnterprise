using InitialEnterprise.Domain.SalesBoundedContext.EntityFramework;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Shared.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace InitialEnterprise.Domain.SalesBoundedContext.Api.Seeding
{
    public static class DbContextExtensions
    {
        public static void EnsureMigrationsApplied(this SalesDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(migration => migration.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(migration => migration.Key);

            if (total.Except(applied).Any())
            {
                context.Database.Migrate();
            }
        }

        public static void EnsureDataSeeded(this SalesDbContext context)
        {
            //basic application data
        }

        public static void EnsureTestdataSeeding(this SalesDbContext context)
        {
            EnsureDataSeeded(context);
         
            if (!context.Customer.Any())
            {
                context.Customer.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Customer>());
                context.SaveChanges();
            }           
                 
        }
    }
}