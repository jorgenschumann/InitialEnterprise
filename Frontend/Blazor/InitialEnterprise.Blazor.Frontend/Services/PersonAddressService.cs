using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class PersonAddressService : IPersonAddressService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "person";
        private readonly string Controller = "addresses";

        public PersonAddressService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid personId, Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.MainUrl}/{Endpoint}/{personId}/{Controller}/{id}/");
        }

        public async Task<PersonAddressDto> Get(Guid personId, Guid id)
        {
            return await requestService.GetAsync<PersonAddressDto>(
                 $"{apiSettings.MainUrl}/{Endpoint}/{personId}/{Controller}/{id}/");
        }

        public async Task<List<CountryDto>> GetCountries()
        {
            return await requestService.GetAsync<List<CountryDto>>(
                $"{apiSettings.MainUrl}/Country");
        }

        public async Task<CommandHandlerAnswerDto<PersonAddressDto>> Post(PersonAddressDto address)
        {
            return await requestService.PostAsync<PersonAddressDto, CommandHandlerAnswerDto<PersonAddressDto>>(
                 $"{apiSettings.MainUrl}/{Endpoint}/{address.PersonId}/{Controller}", address);
        }

        public async Task<CommandHandlerAnswerDto<PersonAddressDto>> Put(PersonAddressDto address)
        {
            return await requestService.PutAsync<PersonAddressDto, CommandHandlerAnswerDto<PersonAddressDto>>(
                 $"{apiSettings.MainUrl}/{Endpoint}/{address.PersonId}/{Controller}", address);
        }
    }
}
