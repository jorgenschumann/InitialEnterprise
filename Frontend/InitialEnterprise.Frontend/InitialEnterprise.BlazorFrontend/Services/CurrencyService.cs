using InitialEnterprise.BlazorFrontend.Infrastructure;
using InitialEnterprise.BlazorFrontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        public CurrencyService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.Url}/currency/{id}");
        }

        public async Task<IEnumerable<CurrencyDto>> Fetch()
        {
            return await requestService.GetAsync<List<CurrencyDto>>(
                $"{apiSettings.Url}/currency");
        }

        public async Task<CurrencyDto> Fetch(Guid id)
        {
            return await requestService.GetAsync<CurrencyDto>
                ($"{apiSettings.Url}/currency/{id}");
        }

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Post(CurrencyDto currency)
        {
            return await requestService.PostAsync<CurrencyDto, CommandHandlerAnswerDto<CurrencyDto>>(
                $"{apiSettings.Url}/currency", currency);
        }

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Put(CurrencyDto currency)
        {
            return await requestService.PutAsync<CurrencyDto, CommandHandlerAnswerDto<CurrencyDto>>(
                         $"{apiSettings.Url}/currency/{currency.Id}", currency);
        }
    }
}
