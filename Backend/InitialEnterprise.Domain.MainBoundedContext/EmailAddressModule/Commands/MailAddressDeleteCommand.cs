using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class EmailAddressDeleteCommand : DomainCommand
    {
        public Guid PersonId { get; set; }
        public Guid MailAddressId { get; set; }
    }
}