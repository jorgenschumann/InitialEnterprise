using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class AddressDeleteCommand : DomainCommand
    {
        public Guid PersonId { get; set; }
        public Guid AddressId { get; set; }
    }
}