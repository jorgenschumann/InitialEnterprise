using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public static class DbContextSeeding
    {
        public static IWebHost Seed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetService<MainDbContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.EnsureTestdataSeeding();
            }
            return host;
        }
    }
}