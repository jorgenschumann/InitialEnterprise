using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class UserNavigationMenuGroupItem : Entity
    {
        [JsonProperty]
        public string DisplayName { get; private set; }

        [JsonProperty]
        public string Href { get; private set; }

        [JsonProperty]
        public string Icon { get; private set; }

        [JsonProperty]
        public Guid GroupId { get; private set; }
        
        public virtual UserNavigationMenuGroup Group { get; private set; }
    }
}
