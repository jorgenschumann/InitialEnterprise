using System;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class EmailAddress: Entity
    {
        public EmailAddress(CreateMailAddressCommand command)
        {
           this.CopyPropertiesFrom(command);
        }

        public string MailAddress { get; }
      
        public virtual Person Person { get;  }
    }
}