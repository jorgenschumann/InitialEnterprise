using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate
{
    public class EmailAddress : Entity
    {
        [JsonProperty]
        public string MailAddress { get; private set; }

        [JsonProperty]
        public string MailAddressType { get; private set; }

        [JsonProperty]
        public Guid PersonId { get; private set; }

        [JsonProperty]
        public bool IsPrimary { get; set; }

        public virtual Person Person { get; private set; }

        [JsonConstructor]
        private EmailAddress()
        {
        }
        
        public EmailAddress(EmailAddressCreateCommand command)
        {
            this.CopyPropertiesFrom(command);          
        }

        public EmailAddress Take(EmailAddressUpdateCommand command)
        {
            this.CopyPropertiesFrom(command);

            return this;
        }     
    }
}