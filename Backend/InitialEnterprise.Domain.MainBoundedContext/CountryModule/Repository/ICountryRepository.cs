using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<IEnumerable<Country>> Query(CountryQuery query);
        
        Task<Country> Query(Guid id);
    }
}