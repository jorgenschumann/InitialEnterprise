using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

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
            var countries = await dispatcher.Query<CountryQuery, IEnumerable<Country>>(query);
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
            var country = await dispatcher.Query<CountryQuery, Country>(query);
            return Mapper.Map(country).ToANew<CountryDto>();
        }
    }
}
