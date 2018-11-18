using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Frontend.Modules.Currency;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;


namespace Blazor.Frontend.Pages.Currency
{ 
    public class CurrencyMainModel : BlazorComponent
    {
        string CurrencyEndpoint = "http://localhost:63928/api/currency/";

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }        
        
        protected  IEnumerable<CurrencyDto> Currencies { get; set; }

        public async Task Get()
        {
            Currencies = await Http.GetJsonAsync<List<CurrencyDto>>(CurrencyEndpoint);
        }
    }                    
}
