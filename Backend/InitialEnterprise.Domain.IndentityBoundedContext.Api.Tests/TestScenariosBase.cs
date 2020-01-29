using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests
{
    public abstract class TestScenariosBase
    {
        protected const string directory = "ApiServices";

        public TestServer CreateServer(string directory = null)
        {
            var currentDirectory = Directory.GetCurrentDirectory() + $"\\{directory}";

            return TestServerCache.FromCache(currentDirectory, () => CreateServerInternal(currentDirectory));
        }

        private TestServer CreateServerInternal(string currentDirectory)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            {
                webHostBuilder.UseContentRoot(currentDirectory);
                webHostBuilder.UseStartup<Startup>();
                webHostBuilder.UseEnvironment("Test");
                webHostBuilder.ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                });
            }

            return new TestServer(webHostBuilder);
        }

        public StringContent SerializeContentString(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }

        public async Task<TModel> DeserializeContentStringAsync<TModel>(HttpResponseMessage model)
        {
            var contentString = await model.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(contentString);
        }
    }
}