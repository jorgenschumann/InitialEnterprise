using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class CountryApplication : ICountryApplication
    {
        private readonly IDispatcher dispatcher;

        public CountryApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<IEnumerable<CountryDto>> Query()
        {
            var query = new CountryQuery();
            var countries = await dispatcher.GetResultAsync<CountryQuery, IEnumerable<Country>>(query);
            var countryDtos = new List<CountryDto>();
            foreach (var country in countries)
            {
                var countryDto =new CountryDto { Id = country.Id, Name = country.Name, UserId = country.UserId };
                foreach (var province in country.Provinces)
                {
                    countryDto.Provinces.Add(province.Name);
                }

                countryDtos.Add(countryDto);
            }
            return countryDtos;               
        }

        public async Task<CountryDto> Query(Guid id)
        {
            var query = new CountryQuery { CountryId = id };
            var country = await dispatcher.GetResultAsync<CountryQuery, Country>(query);
            return Mapper.Map(country).ToANew<CountryDto>();
        }
    }
}
