using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class UserNavigation
    {
        public string DisplayName { get; set; }
        public List<UserNavigationMenuGroup> Groups { get; set; } = new List<UserNavigationMenuGroup>();
    }
}
