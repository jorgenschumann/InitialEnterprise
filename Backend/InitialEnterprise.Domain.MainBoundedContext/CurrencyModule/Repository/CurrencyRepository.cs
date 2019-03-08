using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IMainDbContext mainDbContext;

        public CurrencyRepository(IMainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public Currency Update(Currency currency)
        {
            var addedCurrency = mainDbContext.Currency.Update(currency);
            mainDbContext.SaveEntitiesAsync();
            return addedCurrency.Entity;
        }

        public async Task<Currency> Query(Guid currencyId)
        {
            return await mainDbContext.Currency.SingleAsync(c => c.Id == currencyId);
        }

        public async Task<Currency> Insert(Currency currency)
        {
            var addedCurrency = await mainDbContext.Currency.AddAsync(currency);
            await mainDbContext.SaveEntitiesAsync();
            return addedCurrency.Entity;
        }

        public async Task<IEnumerable<Currency>> Query(CurrencyQuery query)
        {
            return await mainDbContext.Currency.ToListAsync();
        }
    }
}