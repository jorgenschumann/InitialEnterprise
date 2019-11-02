using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public interface ICurrencyApplication
    {
        Task<IEnumerable<CurrencyDto>> Query();

        Task<CurrencyDto> Query(Guid id);

        Task<IEnumerable<CurrencyDto>> Query(IQuery model);

        Task<ICommandHandlerAggregateAnswer> Insert(CurrencyDto model);

        Task<ICommandHandlerAggregateAnswer> Update(CurrencyDto model);
    }
}