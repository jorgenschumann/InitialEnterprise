using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;


namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class ClaimsAuthorizationHandler : AuthorizationHandler<ClaimRequirement>
    {
        IHttpContextAccessor httpContextAccessor = null;

        public ClaimsAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ClaimRequirement requirement)
        {
            var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                 
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == requirement.ClaimName);

            if (claim != null && claim.Value.Contains(requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }  
}