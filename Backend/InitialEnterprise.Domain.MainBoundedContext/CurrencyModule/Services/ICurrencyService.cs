using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services
{
    public interface ICurrencyService
    {        
        Task<Currency> Read(Guid currencyId);
    }

}
