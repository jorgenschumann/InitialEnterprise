using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;

namespace InitialEnterprise.Infrastructure.Api.Middlewares
{  
    public class AuthenticatedTestRequestMiddleware
    {
        public const string TestingCookieAuthentication = "TestCookieAuthentication";
        public const string TestingHeader = "X-Integration-Testing";
        public const string TestingHeaderValue = "Integration-Testing-Value";

        private readonly RequestDelegate _next;

        public AuthenticatedTestRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains(TestingHeader) && 
                context.Request.Headers[TestingHeader].First().Equals(TestingHeaderValue))
            {              
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.NameIdentifier, "12345"),
                    new Claim("Currency","Read"),
                    new Claim("Currency","Write")
                }, TestingCookieAuthentication);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                context.User = claimsPrincipal;              
            }

            await _next(context);
        }
    }
}



