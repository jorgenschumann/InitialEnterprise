using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Infrastructure.CQRS.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries
{
    public class QueryCurrencyHandlerAsync: IQueryHandlerAsync<GetCurrency, Currency>
    {
        private readonly ICurrencyService currencyService;

        public QueryCurrencyHandlerAsync(ICurrencyService currencyService )
        {
            this.currencyService = currencyService;
        }

        public async Task<Currency> RetrieveAsync(GetCurrency query)
        {
            return await currencyService.Read(query.Id);
        }
    }

    public class GetCurrency : IQuery
    {
        public Guid Id { get; set; }
    }
    
}
