using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IDispatcher dispatcher;

        public PersonApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

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

        public async Task<IEnumerable<PersonDto>> Query()
        {
            var personQuery = new PersonQuery();
            var people = await dispatcher.GetResultAsync<PersonQuery, IEnumerable<Person>>(personQuery);
            return Mapper.Map(people).ToANew<IEnumerable<PersonDto>>();
        }

        public async Task<ICommandHandlerAnswer> Update(PersonDto model)
        {
            var command = Mapper.Map(model).ToANew<UpdatePersonCommand>();
            return await dispatcher.SendAsync<UpdatePersonCommand, Person>(command);
        }
    }
}
