using System.Collections.Generic;

namespace InitialEnterprise.Shared.Dtos
{
    public class UserNavigationMenuGroupDto
    {
        public string DisplayName { get; set; }

        public List<UserNavigationMenuGroupItemDto> Entries { get; set; } = new List<UserNavigationMenuGroupItemDto>();
    }
}
