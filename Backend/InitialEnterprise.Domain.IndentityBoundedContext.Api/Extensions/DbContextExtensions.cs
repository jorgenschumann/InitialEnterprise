using InitialEnterprise.Shared.DataSeeding;
using InitialEnterprise.Domain.IndentityBoundedContext.EntityFramework;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Extensions
{
    public static class DbContextExtensions
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
 

            if (!context.Users.Any())
            {
                context.Users.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUser>());
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationRole>());
                context.SaveChanges();
            }

            if (!context.RoleClaims.Any())
            {
                context.RoleClaims.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationRoleClaim>());
                context.SaveChanges();
            }

            if (!context.UserClaims.Any())
            {
                context.UserClaims.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUserClaim>());
                context.SaveChanges();
            }        

            if (!context.UserRoles.Any())
            {
                context.UserRoles.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUserRole>());
                context.SaveChanges();
            }            
        }
    }
}