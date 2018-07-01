using System;
using System.Threading.Tasks;
using AutoMapper;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public class CurrencyApplication : ICurrencyApplication
    {
        private readonly IDispatcher dispatcher;

        public CurrencyApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task Insert(CurrencyDto currencyDto)
        {
            var command = Mapper.Map<CurrencyDto, CreateCurrencyCommand>(currencyDto);
            await dispatcher.SendAsync<CreateCurrencyCommand, CurrencyModule.Aggregate.Currency>(command);
        }

        public async Task<CurrencyDto> Query(Guid id)
        {
            var query = new CurrencyQuery {Id = id};
            var currency = await dispatcher.GetResultAsync<CurrencyQuery, CurrencyModule.Aggregate.Currency>(query);
            return Mapper.Map<CurrencyModule.Aggregate.Currency, CurrencyDto>(currency);
        }
    }
}