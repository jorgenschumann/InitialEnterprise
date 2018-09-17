using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    public static class TestServerExtensions
    {
        public static HttpClient CreateAuthClient(this TestServer server)
        {
            var client = server.CreateClient();
            client.DefaultRequestHeaders.Add(
                "X-Integration-Testing",
                "Integration-Testing-Value");

            return client;
        }
    }
}