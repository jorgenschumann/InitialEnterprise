using System.IO;
using System.Net.Http;
using System.Text;
using InitialEnterprise.Infrastructure.Api.Middlewares;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

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

        public StringContent BuildContentString(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }       
    }   
}