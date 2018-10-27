using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class EmailAddress : Entity
    {
        [JsonConstructor]
        private EmailAddress()
        {

        }

        public EmailAddress(CreateMailAddressCommand command)
        {
            this.CopyPropertiesFrom(command);
        }

        [JsonProperty]
        public string MailAddress { get; private set; }

        [JsonProperty]
        public Guid PersonId { get; private set; }

        public virtual Person Person { get; private set; }
    }
}