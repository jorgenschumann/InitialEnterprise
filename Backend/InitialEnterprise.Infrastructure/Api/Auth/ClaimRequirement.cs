using Microsoft.AspNetCore.Authorization;

namespace InitialEnterprise.Infrastructure.Api.Auth
{
    public class ClaimRequirement : IAuthorizationRequirement
    {
        public ClaimRequirement()
        {
        }

        public ClaimRequirement(string claimName, string claimValue)
        {
            ClaimName = claimName;
            ClaimValue = claimValue;
        }

        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}