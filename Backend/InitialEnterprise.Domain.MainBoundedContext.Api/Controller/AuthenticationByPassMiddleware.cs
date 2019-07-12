using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    public class AuthenticationByPassMiddleware
    {
        private const string AuthorizationHeaderKey = "Authorization";
        private const string BearerPreafix = "Bearer ";

        private readonly RequestDelegate _next;
        private readonly IJwtSecurityTokenBuilder jwtSecurityTokenBuilder;

        public AuthenticationByPassMiddleware(RequestDelegate next, IJwtSecurityTokenBuilder jwtSecurityTokenBuilder)
        {
            _next = next;
            this.jwtSecurityTokenBuilder = jwtSecurityTokenBuilder;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains(AuthorizationHeaderKey))
            {
                var user = SeedDataBuilder.BuildType<ApplicationUser>();
                user.Claims = SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUserClaim>()
                    as ICollection<ApplicationUserClaim>;

                context.Request.Headers.Add(AuthorizationHeaderKey,
                    BearerPreafix + jwtSecurityTokenBuilder.CreateToken(
                        user));
            }

            await _next.Invoke(context);
        }
    }
}