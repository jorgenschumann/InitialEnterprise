using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonApplication : IPersonApplication
    {
        public Task<CommandHandlerAnswerDto<PersonDto>> Insert(PersonDto model)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> Query(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonDto>> Query(IQuery model)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandHandlerAnswer> Update(PersonDto model)
        {
            throw new NotImplementedException();
        }
    }
}
