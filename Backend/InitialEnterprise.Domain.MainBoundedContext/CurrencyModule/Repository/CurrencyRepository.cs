using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public IUnitOfWork UnitOfWork => mainDbContext as IUnitOfWork;

        private readonly MainDbContext mainDbContext;

        public CurrencyRepository(MainDbContext context)
        {
            this.mainDbContext = context;
        }

        public async Task<Currency> Query(Guid currencyId)
        {
            return await mainDbContext.Currencies.FindAsync(currencyId);
        }

        public async Task<Currency> Insert(Currency currency)
        {
            var addedCurrency = await mainDbContext.Currencies.AddAsync(currency);

            return addedCurrency.Entity;
        }
    }
}