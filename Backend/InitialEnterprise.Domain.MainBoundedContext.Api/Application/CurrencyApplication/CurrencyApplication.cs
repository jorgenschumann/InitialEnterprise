using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public class CurrencyApplication : ICurrencyApplication
    {
        private readonly IDispatcher dispatcher;

        public CurrencyApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
           
        public async Task<ICommandHandlerAggregateAnswer> Insert(CurrencyDto model)
        {
            var command = Mapper.Map(model).ToANew<CurrencyCreateCommand>();
            return await dispatcher.Send<CurrencyCreateCommand, CurrencyModule.Aggregate.Currency>(command);
        }

        public async Task<CurrencyDto> Query(Guid id)
        {
            var currenyQuery = new CurrencyQuery { Id = id };
            var currency = await dispatcher.Query<CurrencyQuery, CurrencyModule.Aggregate.Currency>(currenyQuery);
            return Mapper.Map(currency).ToANew<CurrencyDto>();
        }

        public async Task<IEnumerable<CurrencyDto>> Query(IQuery model)
        {
            var currenyQuery = model as CurrencyQuery;
            var currencies = await dispatcher.Query<CurrencyQuery, IEnumerable<CurrencyModule.Aggregate.Currency>>(currenyQuery);
            return Mapper.Map(currencies).ToANew<IEnumerable<CurrencyDto>>();
        }

        public async Task<IEnumerable<CurrencyDto>> Query()
        {
            var currenyQuery = new CurrencyQuery();
            var currencies = await dispatcher.Query<CurrencyQuery, IEnumerable<CurrencyModule.Aggregate.Currency>>(currenyQuery);
            return Mapper.Map(currencies).ToANew<IEnumerable<CurrencyDto>>();
        }

        public async Task<ICommandHandlerAggregateAnswer> Update(CurrencyDto model)
        {
            var command = Mapper.Map(model).ToANew<CurrencyUpdateCommand>();
            return await dispatcher.Send<CurrencyUpdateCommand, CurrencyModule.Aggregate.Currency>(command);
        }
    }
}