
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class EmailAddressCreateCommand : BaseMailAddressCommand
    {
        public EmailAddressCreateCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}