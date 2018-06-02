using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public Currency Save(Currency currency)
        {            
            throw new System.NotImplementedException();
        }
    }

}
