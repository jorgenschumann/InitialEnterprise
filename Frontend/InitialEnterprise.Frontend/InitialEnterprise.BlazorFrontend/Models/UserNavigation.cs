using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Models
{
    public class UserNavigation
    {
        public string DisplayName { get; set; }
        public List<UserNavigationMenuGroup> Groups { get; set; } = new List<UserNavigationMenuGroup>();
    }

    public class UserNavigationMenuGroup
    {
        public string DisplayName { get; set; }

        public List<UserNavigationMenuGroupItem> Entries { get; set; } = new List<UserNavigationMenuGroupItem>();
    }

    public class UserNavigationMenuGroupItem
    {
        public string DisplayName { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
    }

}
