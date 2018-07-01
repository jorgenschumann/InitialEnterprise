﻿using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    public abstract class TestScenariosBase
    {
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

        public StringContent BuildContentString(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }
    }
}