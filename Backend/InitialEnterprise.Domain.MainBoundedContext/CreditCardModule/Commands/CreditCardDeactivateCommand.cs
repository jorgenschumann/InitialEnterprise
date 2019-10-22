using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands
{
    public class CreditCardDeactivateCommand : DomainCommand
    {
        public Guid PersonId { get; set; }
        public Guid CreditCardId { get; set; }
    }
}