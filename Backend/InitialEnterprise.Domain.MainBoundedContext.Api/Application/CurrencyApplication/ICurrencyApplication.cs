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
        Task<CurrencyDto> Query(Guid id);

        Task<IEnumerable<CurrencyDto>> Query(IQuery model);

        Task<CommandHandlerAnswerDto<CurrencyDto>> Insert(CurrencyDto model);

        Task<ICommandHandlerAnswer> Update(CurrencyDto model);
    }

    public class DomainEventDto
    {
        public Guid Id { get; set; }

        public Guid AggregateRootId { get; set; }

        public Guid CommandId { get; set; }

        public long Version { get; set; }

        public Guid UserId { get; set; }

        public string Source { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}