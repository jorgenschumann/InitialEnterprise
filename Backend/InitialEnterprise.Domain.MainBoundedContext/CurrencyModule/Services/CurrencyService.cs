using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Domain.SharedKernel;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services
{
    public class CurrencyService : ICurrencyService , IInjectableDomainService
    {
        private readonly ICurrencyRepository currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<Currency> Read(Guid currencyId)
        {
            return await currencyRepository.ReadAsync(currencyId);
        }

        public Currency Save(Currency currency)
        {            
            throw new System.NotImplementedException();
        }
    }

}
