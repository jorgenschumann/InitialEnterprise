using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class AddressCreateCommand : BaseAddressCommand
    {
        public AddressCreateCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}