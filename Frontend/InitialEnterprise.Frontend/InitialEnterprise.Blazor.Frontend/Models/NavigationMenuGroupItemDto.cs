using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Blazor.Frontend.Models
{
    public class NavigationMenuGroupItemDto
    {
        public string DisplayName { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public bool Active { get; set; } = false;
        public ClaimRequirementDto ClaimRequirement { get; set; }
    }
}
