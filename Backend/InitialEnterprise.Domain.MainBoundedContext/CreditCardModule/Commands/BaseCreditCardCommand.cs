using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class BaseCreditCardCommand : DomainCommand
    {
        public CreditCardType CreditCardType { get; private set; }

        public string CardNumber { get; private set; }

        public byte ExpireMonth { get; private set; }

        public short ExpireYear { get; private set; }

        public Guid PersonId { get; private set; }

        public virtual Person Person { get; private set; }
    }
}

