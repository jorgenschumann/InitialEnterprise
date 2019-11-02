using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Pages.Currency
{
    public class CurrencyController
    {
        private readonly ICurrencyService currencyService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;
        private readonly NavigationManager navigationManager;

        public CurrencyController(
            ICurrencyService CurrencyService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService,
            NavigationManager navigationManager
            )
        {
            currencyService = CurrencyService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
            this.navigationManager = navigationManager;
        }

        private CurrencyDetailsView currencyDetailsView;
        private CurrencyListView currencyListView;

        public async Task SetView(CurrencyDetailsView view)
        {
            this.currencyDetailsView = view;
            this.currencyDetailsView.Id = this.currencyDetailsView.Parameters.Get<string>(nameof(CurrencyDto.Id));
        }

        public async Task SetView(CurrencyListView view)
        {
            this.currencyListView = view;
        }

        public async Task Fetch()
        {
            using (busyIndicatorService.Show())
            {
                this.currencyListView.Currencies = await currencyService.Fetch();
            }
        }

        public async Task Fetch(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                this.currencyDetailsView.Currency = await currencyService.Fetch(id);
            }
        }

        public async Task Delete(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await currencyService.Delete(id);
                navigationManager.NavigateTo("/currency/list");
            }
        }

        public async Task Save(CurrencyDto currency , EditContext context)
        { 
            using (busyIndicatorService.Show())
            {
                var answer =  
                    currency.Id != Guid.Empty ? 
                    await currencyService.Put(currency): 
                    await currencyService.Post(currency);
        
                this.currencyDetailsView.Currency = answer.AggregateRoot ?? currency;
                this.currencyDetailsView.ValidationResult = answer.ValidationResult;
                this.currencyDetailsView.DisplayErrors(context);
            }
        }

    }
}
