using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CurrencyRepository : ICurrencyRepository, IInjectable
    {
        public IUnitOfWork UnitOfWork => mainDbContext as IUnitOfWork;

        private readonly IMainDbContext mainDbContext;

        public CurrencyRepository(IMainDbContext context)
        {
            this.mainDbContext = context;
        }

        public async Task<Currency> Read(Guid currencyId)
        {
            return await mainDbContext.Currencies.FindAsync(currencyId);
        }

        public async Task<Currency> Add(Currency currency)
        {
            var result = await mainDbContext.Currencies.AddAsync(currency);

            return result.Entity;
        }
    }
}
