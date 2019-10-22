using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class BaseMailAddressCommand : DomainCommand
    {
        public string MailAddress { get; set; }

        public string MailAddressType { get; set; }

        public Guid PersonId { get; set; }

        public bool IsPrimary { get; set; }
    }
}