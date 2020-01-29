using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate
{
    public class PersonAddress: Entity
    {
        [JsonProperty]
        public Guid PersonId { get; private set; } // PersonId              

        [JsonProperty]
        public string Street { get; private set; }

        [JsonProperty]
        public string Number { get; private set; }

        [JsonProperty]
        public string City { get; private set; }

        [JsonProperty]
        public string Country { get; private set; }

        [JsonProperty]
        public string Province { get; private set; }

        [JsonProperty]
        public string Zip { get; private set; }

        [JsonProperty]
        public bool IsPrimary { get; private set; }

        public virtual Person Person { get; private set; }

        [JsonConstructor]
        public PersonAddress()
        {
        }

        public PersonAddress(AddressCreateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }

        public void Take(AddressUpdateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }
    }
}
