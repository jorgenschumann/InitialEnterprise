using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.DDD.Annotations;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    [DomainRepository]
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly MainDbContext mainDbContext;
        public CurrencyRepository(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public Currency Save(Currency currency)
        {
           return mainDbContext.Currencies.Add(currency).Entity;
        }
    }
}
