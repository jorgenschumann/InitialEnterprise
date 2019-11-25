using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class UserNavigationMenuGroup
    {
        public string DisplayName { get; set; }

        public List<UserNavigationMenuGroupItem> Entries { get; set; } = new List<UserNavigationMenuGroupItem>();
    }
}
