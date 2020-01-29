using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "person";
        private readonly string Controller = "creditcards";

        public CreditCardService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }
    
        public async Task<CreditCardDto> Get(Guid personId, Guid id)
        {
            return await requestService.GetAsync<CreditCardDto>(
             $"{apiSettings.MainUrl}/{Endpoint}/{personId}/{Controller}/{id}/");
        }

        public async Task<CommandHandlerAnswerDto<CreditCardDto>> Put(CreditCardDto card)
        {
            return await requestService.PutAsync<CreditCardDto, CommandHandlerAnswerDto<CreditCardDto>>(
                 $"{apiSettings.MainUrl}/{Endpoint}/{card.PersonId}/{Controller}", card);
        }

        public async Task<CommandHandlerAnswerDto<CreditCardDto>> Post(CreditCardDto card)
        {
            return await requestService.PostAsync<CreditCardDto, CommandHandlerAnswerDto<CreditCardDto>>(
                   $"{apiSettings.MainUrl}/{Endpoint}/{card.PersonId}/{Controller}", card);
        }
       
        public async Task Delete(Guid personId, Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.MainUrl}/{Endpoint}/{personId}/{Controller}/{id}/");
        }

        public async Task<List<CreditCardTypeDto>> GetCreditCardTypes()
        {
            return await requestService.GetAsync<List<CreditCardTypeDto>>(
                $"{apiSettings.MainUrl}/CreditCard/CreditCardTypes");
        }
    }
}
