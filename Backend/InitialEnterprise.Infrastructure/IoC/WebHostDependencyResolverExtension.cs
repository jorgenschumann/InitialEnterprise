using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Infrastructure.IoC
{
    public static class WebHostDependencyResolverExtension
    {
        public static TService GetService<TService>(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var scopedService = services.GetRequiredService<TService>();
                return scopedService;
            }
        }
    }
}