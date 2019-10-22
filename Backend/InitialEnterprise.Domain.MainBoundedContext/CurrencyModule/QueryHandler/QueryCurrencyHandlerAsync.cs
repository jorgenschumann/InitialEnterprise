using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryCountryHandlerAsync :
        IQueryHandlerAsync<CountryQuery, Country>,
        IQueryHandlerAsync<CountryQuery, IEnumerable<Country>>
    {
        private readonly ICountryRepository countryRepository;

        public QueryCountryHandlerAsync(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<Country> Retrieve(CountryQuery query)
        {
            return await countryRepository.Query(query.CountryId);
        }

        async Task<IEnumerable<Country>> IQueryHandlerAsync<CountryQuery, IEnumerable<Country>>.Retrieve(CountryQuery query)
        {
            return await countryRepository.Query(query);
        }
    }
}