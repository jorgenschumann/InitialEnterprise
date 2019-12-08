using System.Collections.Generic;

namespace InitialEnterprise.Blazor.Frontend.Models
{
    public class NavigationMenuGroupDto
    {
        public string DisplayName { get; set; }

        public List<NavigationMenuGroupItemDto> Entries { get; set; } = new List<NavigationMenuGroupItemDto>();
    }
}
