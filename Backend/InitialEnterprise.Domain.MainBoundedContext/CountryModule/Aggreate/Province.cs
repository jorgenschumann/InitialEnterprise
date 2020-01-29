using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate
{
    public class Province: Entity
    {       
        [JsonProperty]
        public Guid CountryId { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        public virtual Country Country { get; private set; }

        [JsonConstructor]
        public Province()
        {
        }

    }
}
