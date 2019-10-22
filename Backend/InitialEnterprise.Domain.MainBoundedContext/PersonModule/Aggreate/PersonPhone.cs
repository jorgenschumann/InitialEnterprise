using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonPhone : Entity
    { 
        [JsonProperty]
        public string PhoneNumber { get; }

        [JsonProperty]
        public DateTime ModifiedDate { get; }

        [JsonProperty]
        public virtual Person Person { get; }

        [JsonProperty]
        public Guid PhoneNumberTypeID { get; }

        [JsonProperty]
        public virtual PhoneNumberType PhoneNumberType { get; }

        [JsonConstructor]
        private PersonPhone()
        {
        }
    }
}