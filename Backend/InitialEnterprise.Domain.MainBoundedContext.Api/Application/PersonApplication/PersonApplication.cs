using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IDispatcher dispatcher;     

        public PersonApplication(IDispatcher dispatcher, IHttpContextAccessor httpContextAccessor)
        {
            this.dispatcher = dispatcher;         
        }

        public async Task<ICommandHandlerAggregateAnswer> Insert(PersonDto model)
        {
            var command = Mapper.Map(model).ToANew<PersonCreateCommand>();
            return await dispatcher.Send<PersonCreateCommand, Person>(command);
        }

        public async Task<PersonDto> Query(Guid id)
        {
            var query = new PersonQuery { Id = id };
            var person = await dispatcher.Query<PersonQuery, Person>(query);
            return Mapper.Map(person).ToANew<PersonDto>();
        }

        public async Task<IEnumerable<PersonDto>> Query(IQuery model)
        {            
            var people = await dispatcher.Query<PersonQuery, IEnumerable<Person>>(model as PersonQuery);
            return Mapper.Map(people).ToANew<IEnumerable<PersonDto>>();
        }

        public async Task<IEnumerable<PersonDto>> Query()
        {
            var personQuery = new PersonQuery();
            var people = await dispatcher.Query<PersonQuery, IEnumerable<Person>>(personQuery);
            return Mapper.Map(people).ToANew<IEnumerable<PersonDto>>();
        }

        public async Task<ICommandHandlerAggregateAnswer> Update(PersonDto model)
        {
            var command = Mapper.Map(model).ToANew<PersonUpdateCommand>();           
            return await dispatcher.Send<PersonUpdateCommand, Person>(command);
        }
    }
}
