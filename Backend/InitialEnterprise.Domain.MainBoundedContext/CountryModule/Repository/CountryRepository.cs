using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMainDbContext mainDbContext;

        public CountryRepository(IMainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;
        
        public async Task<Country> Query(Guid countryId)
        {
            return await mainDbContext.Country.SingleAsync(c => c.Id == countryId);
        }

        public async Task<IEnumerable<Country>> Query(CountryQuery query)        
        {
            return await mainDbContext.Country.Include(x => x.Provinces).ToListAsync();
        }
    }
}