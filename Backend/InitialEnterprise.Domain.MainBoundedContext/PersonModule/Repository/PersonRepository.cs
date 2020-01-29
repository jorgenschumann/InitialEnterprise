using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMainDbContext context;
     
        public PersonRepository(IMainDbContext context)
        {
            this.context = context;           
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<Person> Insert(Person person)
        {
            var added = await context.Person.AddAsync(person);
            await context.SaveEntitiesAsync();
            return added.Entity;
        }       
     
        public async Task<Person> Query(Guid personId)
        {
            return await context
                .Person
                .Include(p => p.EmailAddresses)
                .Include(p => p.Addresses)
                .Include(p => p.CreditCards)
                .SingleOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<IEnumerable<Person>> Query(PersonQuery query)
        {
            return await context.Person.ToListAsync();
        }

        public async Task<Person> Update(Person person)
        {
            var updated = context.Person.Update(person);
            await context.SaveEntitiesAsync();
            return updated.Entity;
        }
    }
}