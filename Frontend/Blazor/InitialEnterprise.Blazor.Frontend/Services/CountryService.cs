using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "country";

        public CountryService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task<List<CountryDto>> Get()
        {
            return await requestService.GetAsync<List<CountryDto>>(
                $"{apiSettings.MainUrl}/{Endpoint}");
        }
    }
}
