using InitialEnterprise.Frontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Pages.Currency
{
    public class CurrencyListView : ViewComponentBase
    {      
        public List<CurrencyDto> Currencies { get; set; } = new List<CurrencyDto>();
    }
}
