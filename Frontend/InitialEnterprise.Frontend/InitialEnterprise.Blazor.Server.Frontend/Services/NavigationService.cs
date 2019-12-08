using InitialEnterprise.Blazor.Frontend.Models;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IUserService userService; 

        public NavigationService(IUserService userService)
        {            
            this.userService = userService;         
        }

        public async Task<NavigationDto> GetUserNavigation(Guid userId)
        {
            var navigation = GetPosibleNavigation();
            
            var userClaims = await userService.GetClaims(userId);
                        
            foreach (var group in navigation.Groups)
            {
                foreach (var entry in group.Entries)
                {
                    entry.Active = HasClaim(userClaims, entry.ClaimRequirement);
                }
            }
            return navigation;
        }     

        public NavigationDto GetPosibleNavigation()
        {
            var navigation = new NavigationDto();

            var mainDataNavigationGroup = new NavigationMenuGroupDto
            {
                DisplayName = "MainData"
            };
            mainDataNavigationGroup.Entries.Add(new NavigationMenuGroupItemDto
            {
                DisplayName = "Users",
                Href = "user/list",
                Icon = "user",
                ClaimRequirement = new ClaimRequirementDto { ClaimName = "User", ClaimValue = "Query" }
            });
            mainDataNavigationGroup.Entries.Add(new NavigationMenuGroupItemDto
            {
                DisplayName = "Currencies",
                Href = "currency/list",
                Icon = "globe",
                ClaimRequirement = new ClaimRequirementDto { ClaimName = "Currency", ClaimValue = "Query" }
            });
            mainDataNavigationGroup.Entries.Add(new NavigationMenuGroupItemDto
            {
                DisplayName = "People",
                Href = "person/list",
                Icon = "users",
                ClaimRequirement = new ClaimRequirementDto { ClaimName = "User", ClaimValue = "Query" }
            });

            mainDataNavigationGroup.Entries.Add(new NavigationMenuGroupItemDto
            {
                DisplayName = "Country",
                Href = "Country/list",
                Icon = "Countries",
                ClaimRequirement = new ClaimRequirementDto { ClaimName = "Country", ClaimValue = "Query" }
            });

            navigation.Groups.Add(mainDataNavigationGroup);

            return navigation;
        }
        
        private bool HasClaim(List<ClaimDto> claims, ClaimRequirementDto claimRequirement)
        {
            foreach (var claim in claims)
            {
                if (claim.Type == claimRequirement.ClaimName &&
                    claim.Value == claimRequirement.ClaimValue)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
