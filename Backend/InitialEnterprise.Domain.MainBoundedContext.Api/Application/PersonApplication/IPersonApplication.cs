using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public interface IPersonApplication
    {
        Task<IEnumerable<PersonDto>> Query();

        Task<PersonDto> Query(Guid id);

        Task<IEnumerable<PersonDto>> Query(IQuery model);

        Task<ICommandHandlerAggregateAnswer> Insert(PersonDto model);

        Task<ICommandHandlerAggregateAnswer> Update(PersonDto model);
    }
}
