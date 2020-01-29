using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;


namespace InitialEnterprise.Infrastructure.Api.Auth
{
    public class ClaimsAuthorizationHandler : AuthorizationHandler<ClaimRequirement>
    {       
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ClaimRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(
                c => c.Type == requirement.ClaimName && c.Value == requirement.ClaimValue);
            
            if (claim != null)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }  
}