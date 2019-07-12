using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public interface ICurrencyApplication
    {
        Task<IEnumerable<CurrencyDto>> Query();

        Task<CurrencyDto> Query(Guid id);

        Task<IEnumerable<CurrencyDto>> Query(IQuery model);

        Task<CommandHandlerAnswerDto<CurrencyDto>> Insert(CurrencyDto model);

        Task<ICommandHandlerAnswer> Update(CurrencyDto model);
    }
}