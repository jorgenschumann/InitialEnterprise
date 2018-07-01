using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InitialEnterprise.Infrastructure.Api.Middlewares
{
    public class AuthenticationByPassMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public AuthenticationByPassMiddleware(RequestDelegate next)
        {
            requestDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await requestDelegate.Invoke(httpContext);
        }
    }
}