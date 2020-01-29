using InitialEnterprise.Frontend.Component;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Pages.Person.Address
{
    public class AddressDetailsView : ViewComponentBase
    {
        public PersonAddressDto PersonAddress { get; set; } = new PersonAddressDto();
        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();
    }
    
}
