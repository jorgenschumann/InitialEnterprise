using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly MainDbContext mainDbContext;

        public CurrencyRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public Currency Udate(Currency currency)
        {
            var addedCurrency = mainDbContext.Currency.Update(currency);

            return addedCurrency.Entity;
        }

        public async Task<Currency> Query(Guid currencyId)
        {
            return await mainDbContext.Currency.FindAsync(currencyId);
        }

        public async Task<Currency> Insert(Currency currency)
        {
            var addedCurrency = await mainDbContext.Currency.AddAsync(currency);

            return addedCurrency.Entity;
        }

        public async Task<IEnumerable<Currency>> Query(CurrencyQuery query)
        {
            return await mainDbContext.Currency.ToListAsync();
        }
    }
}