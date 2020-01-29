using InitialEnterprise.Frontend.Services;
using InitialEnterprise.Frontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Pages.Country
{
    public class CountryController
    {
        private readonly ICountryService countryService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;

        public CountryController(
            ICountryService countryService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService
            )
        {
            this.countryService = countryService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
        }

        public async Task<List<CountryDto>> Get()
        {
            using (busyIndicatorService.Show())
            {
               return await countryService.Get();
            }
        }
    }
}
