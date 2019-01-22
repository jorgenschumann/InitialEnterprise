using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Seed().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }

    public static class DatabaseSeedInitializer
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