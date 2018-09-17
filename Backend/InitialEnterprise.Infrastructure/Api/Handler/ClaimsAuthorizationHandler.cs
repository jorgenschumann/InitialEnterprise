﻿using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class ClaimsAuthorizationHandler : AuthorizationHandler<ClaimRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ClaimRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == requirement.ClaimName);

            if (claim != null && claim.Value.Contains(requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}