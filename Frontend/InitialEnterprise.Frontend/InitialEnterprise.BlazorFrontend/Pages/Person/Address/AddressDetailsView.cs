using InitialEnterprise.BlazorFrontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.BlazorFrontend.Pages.Person.Address
{
    public class AddressDetailsView : ViewComponentBase
    {
        public PersonAddressDto PersonAddress { get; set; } = new PersonAddressDto();
        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();
    }
    
}
