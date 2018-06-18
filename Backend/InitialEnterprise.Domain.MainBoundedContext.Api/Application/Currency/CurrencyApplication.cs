using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.IoC;
using NewLibrary.ForString;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public class CurrencyApplication : ICurrencyApplication, IInjectable
    {
        private readonly ICurrencyService currencyService;
        private readonly IDispatcher dispatcher;

        public CurrencyApplication(ICurrencyService currencyService, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.currencyService = currencyService;
        }

        public async Task Save(CurrencyDto currencyDto)
        {
            var command = new CreateCurrencyCommand
            {
                Name = currencyDto.Name,
                Rate = currencyDto.Rate.toDecimal(),
                IsoCode = currencyDto.IsoCode
            };

            await dispatcher.SendAsync<CreateCurrencyCommand,CurrencyModule.Aggregate.Currency>(command);
        }
        
        public async Task<CurrencyDto> Read(Guid currencyId)
        {
            var query = new GetCurrency
            {
                Id = currencyId
            };

            var currency = await dispatcher.GetResultAsync<GetCurrency, CurrencyModule.Aggregate.Currency>(query);
            
            return new CurrencyDto { Id = currency.Id, IsoCode = currency.IsoCode, Name = currency.Name, Rate = currency.Rate.ToString() };
        }
    }
}