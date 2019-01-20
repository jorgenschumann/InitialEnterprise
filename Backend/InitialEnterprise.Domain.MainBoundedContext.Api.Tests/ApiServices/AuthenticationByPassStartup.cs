using InitialEnterprise.Domain.MainBoundedContext.Api.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    public class AuthenticationByPassStartup : Startup
    {
        public AuthenticationByPassStartup(IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
            : base(configuration, hostingEnvironment)
        {
        }

        protected override void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
            {
                app.UseMiddleware<AuthenticationByPassMiddleware>();
            }
            else
            {
                base.ConfigureAuth(app);
            }
        }
    }
}