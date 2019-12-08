using InitialEnterprise.Blazor.Frontend.Infrastructure;
using InitialEnterprise.Blazor.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
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
                $"{apiSettings.Url}/{Endpoint}/{id}");
        }

        public async Task<IEnumerable<PersonDto>> Get()
        {
            return await requestService.GetAsync<List<PersonDto>>(
                $"{apiSettings.Url}/{Endpoint}");
        }

        public async Task<PersonDto> Get(Guid id)
        {
            return await requestService.GetAsync<PersonDto>
                ($"{apiSettings.Url}/{Endpoint}/{id}");
        }

        public async Task<CommandHandlerAnswerDto<PersonDto>> Post(PersonDto person)
        {
            return await requestService.PostAsync<PersonDto, CommandHandlerAnswerDto<PersonDto>>(
                $"{apiSettings.Url}/{Endpoint}", person);
        }

        public async Task<CommandHandlerAnswerDto<PersonDto>> Put(PersonDto person)
        {
            return await requestService.PutAsync<PersonDto, CommandHandlerAnswerDto<PersonDto>>(
                         $"{apiSettings.Url}/{Endpoint}/{person.Id}", person);
        }
    }
}
