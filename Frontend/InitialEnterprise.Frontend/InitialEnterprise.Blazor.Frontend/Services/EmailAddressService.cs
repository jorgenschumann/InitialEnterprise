using InitialEnterprise.Blazor.Frontend.Infrastructure;
using InitialEnterprise.Blazor.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "person";
        private readonly string Controller = "emailaddresses";

        public EmailAddressService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task<EmailAddressDto> Get(Guid personId, Guid id)
        {
            return await requestService.GetAsync<EmailAddressDto>(
                $"{apiSettings.Url}/{Endpoint}/{personId}/{Controller}/{id}/");
        }

        public async Task<CommandHandlerAnswerDto<EmailAddressDto>> Put(EmailAddressDto mail)
        {
            return await requestService.PutAsync<EmailAddressDto, CommandHandlerAnswerDto<EmailAddressDto>>(
                 $"{apiSettings.Url}/{Endpoint}/{mail.PersonId}/{Controller}", mail);
        }

        public async Task<CommandHandlerAnswerDto<EmailAddressDto>> Post(EmailAddressDto mail)
        {
            return await requestService.PostAsync<EmailAddressDto, CommandHandlerAnswerDto<EmailAddressDto>>(
                $"{apiSettings.Url}/{Endpoint}/{mail.PersonId}/{Controller}", mail);
        }

        public async Task Delete(Guid personId, Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.Url}/{Endpoint}/{personId}/{Controller}/{id}/");
        }      
    }

}
