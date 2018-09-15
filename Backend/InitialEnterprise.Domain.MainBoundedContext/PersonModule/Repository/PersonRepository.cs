using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainDbContext mainDbContext;

        public PersonRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public Task<Person> Insert(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Query(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}