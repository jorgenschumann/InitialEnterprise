using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands
{
    public class BaseAddressCommand : DomainCommand
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Zip { get; set; }
        
        public Guid PersonId { get; set; }

        public bool IsPrimary { get; set; }
    }
}

