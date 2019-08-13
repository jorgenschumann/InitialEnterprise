using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class CreditCardDeleteCommand : DomainCommand
    {
        public Guid PersonId { get; set; }
        public Guid CreditCardId { get; set; }
    }
}