using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "currency";

        public CurrencyService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.MainUrl}/{Endpoint}/{id}");
        }

        public async Task<List<CurrencyDto>> Fetch()
        {
            return await requestService.GetAsync<List<CurrencyDto>>(
                $"{apiSettings.MainUrl}/{Endpoint}");
        }

        public async Task<CurrencyDto> Fetch(Guid id)
        {
            return await requestService.GetAsync<CurrencyDto>
                ($"{apiSettings.MainUrl}/{Endpoint}/{id}");
        }

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Post(CurrencyDto currency)
        {
            return await requestService.PostAsync<CurrencyDto, CommandHandlerAnswerDto<CurrencyDto>>(
                $"{apiSettings.MainUrl}/{Endpoint}", currency);
        }

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Put(CurrencyDto currency)
        {
            return await requestService.PutAsync<CurrencyDto, CommandHandlerAnswerDto<CurrencyDto>>(
                         $"{apiSettings.MainUrl}/{Endpoint}/{currency.Id}", currency);
        }
    }
}
