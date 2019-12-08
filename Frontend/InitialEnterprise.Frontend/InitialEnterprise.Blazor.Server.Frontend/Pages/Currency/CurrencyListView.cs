using InitialEnterprise.Blazor.Frontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Blazor.Frontend.Pages.Currency
{
    public class CurrencyListView : ViewComponentBase
    {      
        public List<CurrencyDto> Currencies { get; set; } = new List<CurrencyDto>();
    }
}
