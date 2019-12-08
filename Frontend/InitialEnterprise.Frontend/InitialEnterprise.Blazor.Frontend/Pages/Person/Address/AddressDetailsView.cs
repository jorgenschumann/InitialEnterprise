using InitialEnterprise.Blazor.Frontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Blazor.Frontend.Pages.Person.Address
{
    public class AddressDetailsView : ViewComponentBase
    {
        public PersonAddressDto PersonAddress { get; set; } = new PersonAddressDto();
        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();
    }
    
}
