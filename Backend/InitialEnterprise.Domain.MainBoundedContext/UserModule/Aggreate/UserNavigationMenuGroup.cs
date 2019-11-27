﻿using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class UserNavigationMenuGroup : Entity
    {
        [JsonProperty]
        public string DisplayName { get; private set; }

        [JsonProperty]
        public Guid UserNavigationId { get; private set; }

        public virtual UserNavigation UserNavigation { get; private set; }

        [JsonProperty]
        public ICollection<UserNavigationMenuGroupItem> Entries { get; private set; } = new List<UserNavigationMenuGroupItem>();
    }
}
