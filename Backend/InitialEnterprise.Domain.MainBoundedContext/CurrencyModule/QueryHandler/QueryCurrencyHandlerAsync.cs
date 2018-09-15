using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryCurrencyHandlerAsync :
        IQueryHandlerAsync<CurrencyQuery, Currency>,
        IQueryHandlerAsync<IEnumerable<Currency>>
    {
        private readonly ICurrencyRepository currencyRepository;

        public QueryCurrencyHandlerAsync(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<Currency> RetrieveAsync(CurrencyQuery query)
        {
            return await currencyRepository.Query(query.Id);
        }

        public async Task<IEnumerable<Currency>> RetrieveAsync()
        {
            return await currencyRepository.Query();
        }
    }
}