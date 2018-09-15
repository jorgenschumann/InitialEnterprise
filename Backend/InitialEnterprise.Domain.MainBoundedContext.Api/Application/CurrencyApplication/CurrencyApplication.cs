using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public class CurrencyApplication : ICurrencyApplication
    {
        private readonly IDispatcher dispatcher;

        public CurrencyApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Insert(CurrencyDto currencyDto)
        {
            var command = Mapper.Map(currencyDto).ToANew<CurrencyCreateCommand>();
            var asyncResult = await dispatcher.SendAsync<CurrencyCreateCommand, CurrencyModule.Aggregate.Currency>(command);
            return Mapper.Map(asyncResult).ToANew<CommandHandlerAnswerDto<CurrencyDto>>();
        }

        public async Task<CurrencyDto> Query(Guid id)
        {
            var query = new CurrencyQuery { Id = id };
            var currency = await dispatcher.GetResultAsync<CurrencyQuery, CurrencyModule.Aggregate.Currency>(query);
            return Mapper.Map(currency).ToANew<CurrencyDto>();
        }

        public async Task<IEnumerable<CurrencyDto>> Query(IQuery query)
        {
            var currenyQuery = query as CurrencyQuery;
            var currencies = await dispatcher.GetResultAsync<CurrencyQuery, IEnumerable<CurrencyModule.Aggregate.Currency>>(currenyQuery);
            return Mapper.Map(currencies).ToANew<IEnumerable<CurrencyDto>>();
        }

        public async Task<ICommandHandlerAnswer> Update(CurrencyDto currencyDto)
        {
            var command = Mapper.Map(currencyDto).ToANew<CurrencyUpdateCommand>();
            return await dispatcher.SendAsync<CurrencyUpdateCommand, CurrencyModule.Aggregate.Currency>(command);
        }
    }
}