using InitialEnterprise.BlazorFrontend.Pages.Person.Address;
using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Pages.Person.Address
{    public class AddressController
    {
        private readonly IPersonAddressService personAddressService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;
        
        public AddressController(
            IPersonAddressService personAddressService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService

            )
        {
            this.personAddressService = personAddressService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
        }

        private AddressDetailsView addressDetailsView;
        private AddressListView addressListView;

        public async Task SetView(AddressDetailsView addressDetailsView)
        {
            this.addressDetailsView = addressDetailsView;
            this.addressDetailsView.Countries = await personAddressService.GetCountries();
        } 

        public async Task SetView(AddressListView addressListView)
        {
            this.addressListView = addressListView;
        }

        public async Task Get(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                this.addressDetailsView.PersonAddress = await personAddressService.Get(personId, id);
            }
        }

        public async Task Delete(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await personAddressService.Delete(personId, id);
            }
        }

        public async Task<CommandHandlerAnswerDto<PersonAddressDto>> Save(PersonAddressDto address)
        {            
            using (busyIndicatorService.Show())
            {
                if (address.Id != Guid.Empty)
                {
                    return await personAddressService.Put(address);
                }
                return await personAddressService.Post(address);
            }
        }
    }
}
