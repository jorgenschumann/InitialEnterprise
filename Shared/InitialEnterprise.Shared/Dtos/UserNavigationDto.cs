using System.Collections.Generic;

namespace InitialEnterprise.Shared.Dtos
{
    public class UserNavigationDto
    {
        public string DisplayName { get; set; }
        public List<UserNavigationMenuGroupDto> Groups { get; set; } = new List<UserNavigationMenuGroupDto>();
    }
}
