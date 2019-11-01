using InitialEnterprise.BlazorFrontend.Component;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace InitialEnterprise.BlazorFrontend.Pages.Person.Address
{    public class AddressListView : ViewComponentBase
    {
        [Parameter]
        public PersonDto Person { get; set; }

        [Parameter]
        public ICollection<PersonAddressDto> Addresses { get; set; } = new List<PersonAddressDto>();
    }
}
