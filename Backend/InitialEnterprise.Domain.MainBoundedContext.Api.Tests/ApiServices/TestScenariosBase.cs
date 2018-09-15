using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
   
    public abstract class TestScenariosBase
    {
        protected const string directory = "ApiServices";

        protected Assert Assertion;

        public TestScenariosBase()
        {
            Assertion = (Assert)Activator.CreateInstance(typeof(Assert), true);
        }

        public TestServer CreateServer(string directory)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            {
                webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + $"\\{directory}");
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

        public TModel DeserializeContentString<TModel>(HttpResponseMessage model)
        {
            var contentString = model.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(contentString);
        }
    }
}