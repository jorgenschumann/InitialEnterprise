using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class CreditCardCreateCommand : BaseCreditCardCommand
    {
        public CreditCardCreateCommand()
        {
            Id = Guid.NewGuid();
        }
  }
}