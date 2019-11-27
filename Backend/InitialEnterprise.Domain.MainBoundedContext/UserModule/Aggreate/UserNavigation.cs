using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class UserNavigation : Entity
    {
        [JsonProperty]
        public Guid UserId { get; private  set; }       
        
        public virtual ApplicationUser User { get; private set; }

        [JsonProperty]
        public string DisplayName { get; set; }

        [JsonProperty]
        public ICollection<UserNavigationMenuGroup> Groups { get; private set; } = new List<UserNavigationMenuGroup>();
    }
}
