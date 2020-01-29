using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "person";

        public PersonService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.MainUrl}/{Endpoint}/{id}");
        }

        public async Task<IEnumerable<PersonDto>> Get()
        {
            return await requestService.GetAsync<List<PersonDto>>(
                $"{apiSettings.MainUrl}/{Endpoint}");
        }

        public async Task<PersonDto> Get(Guid id)
        {
            return await requestService.GetAsync<PersonDto>
                ($"{apiSettings.MainUrl}/{Endpoint}/{id}");
        }

        public async Task<CommandHandlerAnswerDto<PersonDto>> Post(PersonDto person)
        {
            return await requestService.PostAsync<PersonDto, CommandHandlerAnswerDto<PersonDto>>(
                $"{apiSettings.MainUrl}/{Endpoint}", person);
        }

        public async Task<CommandHandlerAnswerDto<PersonDto>> Put(PersonDto person)
        {
            return await requestService.PutAsync<PersonDto, CommandHandlerAnswerDto<PersonDto>>(
                         $"{apiSettings.MainUrl}/{Endpoint}/{person.Id}", person);
        }
    }
}
