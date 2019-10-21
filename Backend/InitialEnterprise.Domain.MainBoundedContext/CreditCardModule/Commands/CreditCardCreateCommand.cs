using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands
{
    public class CreditCardCreateCommand : BaseCreditCardCommand
    {
        public CreditCardCreateCommand()
        {
            Id = Guid.NewGuid();
        }
  }
}