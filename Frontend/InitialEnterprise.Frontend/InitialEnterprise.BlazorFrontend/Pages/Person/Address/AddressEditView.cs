using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.BlazorFrontend.Pages.Person.Address
{
    public class AddressEditView : Component.ViewComponentBase
    {
        public PersonAddressDto PersonAddress { get; set; } = new PersonAddressDto();

        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();

    }
}
