﻿using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Controller
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

        public async Task<IEnumerable<CurrencyDto>> Fetch()
        {
            using (busyIndicatorService.Show())
            {                
                return await currencyService.Fetch();
            }
        }

        public async Task<CurrencyDto> Fetch(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                return await currencyService.Fetch(id);
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

        public async Task<CommandHandlerAnswerDto<CurrencyDto>> Save(CurrencyDto currency)
        {            
            using (busyIndicatorService.Show())
            {
                if (currency.Id != Guid.Empty){
                    return await currencyService.Put(currency);
                }
                return await currencyService.Post(currency);
            }          
        }
    }
}
