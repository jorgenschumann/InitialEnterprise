using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.QueryHandler
{
    public class PersonCurrencyHandlerAsync :
        IQueryHandlerAsync<PersonQuery, Person>,
        IQueryHandlerAsync<PersonQuery, IEnumerable<Person>>
    {
        private readonly IPersonRepository personRepository;
        public PersonCurrencyHandlerAsync(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Retrieve(PersonQuery query)
        {
            return await personRepository.Query(query);
        }

        async Task<Person> IQueryHandlerAsync<PersonQuery, Person>.Retrieve(PersonQuery query)
        {
            return await personRepository.Query(query.Id);
        }
    }
}
