using InitialEnterprise.BlazorFrontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.BlazorFrontend.Pages.Currency
{
    public class CurrencyListView : ViewComponentBase
    {      
        public List<CurrencyDto> Currencies { get; set; } = new List<CurrencyDto>();
    }
}
