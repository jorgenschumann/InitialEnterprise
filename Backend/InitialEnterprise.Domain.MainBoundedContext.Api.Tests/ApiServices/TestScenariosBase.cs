using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests
{
    public abstract class TestScenariosBase
    {
        public TestServer CreateServer(string directory)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            {
                webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + $"\\{directory}");
                webHostBuilder.UseStartup<Startup>();
            }
            return new TestServer(webHostBuilder);
        }
    }
}