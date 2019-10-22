using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands
{
    public class BaseCreditCardCommand : DomainCommand
    {
        public CreditCardType CreditCardType { get; set; }

        public string CardNumber { get; set; }

        public byte ExpireMonth { get; set; }

        public short ExpireYear { get; set; }

        public Guid PersonId { get; set; }        
    }
}

