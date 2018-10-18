using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public interface IPersonApplication
    {
        Task<IEnumerable<PersonDto>> Query();

        Task<PersonDto> Query(Guid id);

        Task<IEnumerable<PersonDto>> Query(IQuery model);

        Task<CommandHandlerAnswerDto<PersonDto>> Insert(PersonDto model);

        Task<ICommandHandlerAnswer> Update(PersonDto model);

    }
}
