﻿using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate
{
    public class Country : AggregateRoot
    {
        [JsonConstructor]
        private Country()
        {
        }
        
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string IsoCode { get; private set; }

        [JsonProperty]
        public ICollection<Province> Provinces { get; private set; }

    }
}
