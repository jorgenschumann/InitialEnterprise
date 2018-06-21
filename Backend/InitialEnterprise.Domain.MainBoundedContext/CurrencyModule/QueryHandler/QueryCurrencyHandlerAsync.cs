using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryCurrencyHandlerAsync: IQueryHandlerAsync<CurrencyQuery, Currency>
    {
        private readonly ICurrencyRepository currencyRepository;

        public QueryCurrencyHandlerAsync(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<Currency> RetrieveAsync(CurrencyQuery query)
        {
            return await currencyRepository.Read(query.Id);
        }
    }

    public class CurrencyQuery : IQuery
    {
        public Guid Id { get; set; }
    }
    
}
