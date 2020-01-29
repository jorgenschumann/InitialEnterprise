using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Models
{
    public class NavigationDto
    {
        public List<NavigationMenuGroupDto> Groups { get; set; } = new List<NavigationMenuGroupDto>();
    }
}
