﻿using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
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
        private readonly MainDbContext mainDbContext;

        public PersonRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public async Task<Person> Insert(Person person)
        {
            var added = await mainDbContext.Person.AddAsync(person);

            return added.Entity;
        }

        public async Task<Person> Query(Guid personId)
        {
            return await mainDbContext.Person.FindAsync(personId);
        }

        public async Task<IEnumerable<Person>> Query(PersonQuery query)
        {
            return await mainDbContext.Person.ToListAsync();
        }

        public async Task<Person> Update(Person person)
        {
            var updated = mainDbContext.Person.Update(person);

            return updated.Entity;
        }
    }
}