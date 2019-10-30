using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.BlazorFrontend.Pages.Person.Address
{
    public class AddressListView : Component.ViewComponentBase
    {
        public ICollection<PersonAddressDto> Addresses { get; set; } = new List<PersonAddressDto>();
    }
}
