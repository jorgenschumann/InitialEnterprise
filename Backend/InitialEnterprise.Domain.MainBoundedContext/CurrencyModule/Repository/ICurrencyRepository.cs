using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<Currency> Insert(Currency currency);

        Task<Currency> Query(Guid currencyId);


    }
}