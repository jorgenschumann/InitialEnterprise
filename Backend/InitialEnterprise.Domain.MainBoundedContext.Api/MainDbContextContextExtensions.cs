using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{

    //todo: move to a better place 

    public static class MainDbContextContextExtensions
    {
        public static void EnsureMigrationsApplied(this MainDbContext context)
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

        public static void EnsureDataSeeded(this MainDbContext context)
        {
           //basic application data
        }

        public static void EnsureTestdataSeeding(this MainDbContext context)
        {
            EnsureDataSeeded(context);

            context.Currency.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Currency>());
            context.SaveChanges();

            context.Person.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Person>());
            context.SaveChanges();

            var emailAddresses = SeedDataBuilder.BuildTypeCollectionFromFile<EmailAddress>();
            context.EmailAddress.AddRange(emailAddresses);
            context.SaveChanges();

            context.CurrencyRate.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<CurrencyRate>());
            context.SaveChanges();

            context.Users.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUser>());
            context.SaveChanges();

            context.Roles.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationRole>());
            context.SaveChanges();

            context.RoleClaims.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationRoleClaim>());
            context.SaveChanges();

            context.UserClaims.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUserClaim>());
            context.SaveChanges();

            //context.UserRoles.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUserRole>());
            //context.SaveChanges();

        }
    }
}