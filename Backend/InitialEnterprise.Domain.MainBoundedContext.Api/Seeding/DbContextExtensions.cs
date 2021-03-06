﻿using InitialEnterprise.Shared.DataSeeding;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
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
         
            if (!context.Currency.Any())
            {
                context.Currency.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Currency>());
                context.SaveChanges();
            }

            if (!context.Person.Any())
            {
                context.Person.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Person>());
                context.SaveChanges();
            }

            if (!context.EmailAddress.Any())
            {
                context.EmailAddress.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<EmailAddress>());
                context.SaveChanges();
            }

            if (!context.CreditCard.Any())
            {
                context.CreditCard.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<CreditCard>());
                context.SaveChanges();
            }

            if (!context.CurrencyRate.Any())
            {
                context.CurrencyRate.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<CurrencyRate>());
                context.SaveChanges();
            }

            if (!context.Country.Any())
            {
                context.Country.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Country>());
                context.SaveChanges();
            }

            if (!context.Province.Any())
            {
                context.Province.AddRange(SeedDataBuilder.BuildTypeCollectionFromFile<Province>());
                context.SaveChanges();
            }
                 
        }
    }
}