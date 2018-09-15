using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<Currency> Insert(Currency currency);

        Currency Udate(Currency currency);

        Task<Currency> Query(Guid currencyId);

        Task<IEnumerable<Currency>> Query();
    }
}