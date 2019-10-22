using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate
{
    public abstract class Address : Entity
    {
        [JsonProperty]
        public string Street { get; private set; }

        [JsonProperty]
        public string Number { get; private set; }

        [JsonProperty]
        public string Country { get; private set; }

        [JsonProperty]
        public string State { get; private set; }

        [JsonProperty]
        public string Zip { get; private set; }
           
        [JsonProperty]
        public bool IsPrimary { get; private set; }

        [JsonConstructor]
        private Address()
        {
        }

        public Address(AddressCreateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }
    }    
}
