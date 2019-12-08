using Blazored.Modal;
using InitialEnterprise.Blazor.Frontend.Component;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace InitialEnterprise.Blazor.Frontend.Pages.Currency
{
    public class CurrencyDetailsView : ViewComponentBase
    {
        [CascadingParameter] public ModalParameters Parameters { get; set; }

        public string Id { get; set; } 

        public CurrencyDto Currency { get; set; } = new CurrencyDto();
    }    
}
