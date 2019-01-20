using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Tests.ApiControllers
{
    public static class TestServerExtensions
    {
        public static HttpClient CreateAuthClient(this TestServer server)
        {
            var client = server.CreateClient();

            return client;
        }
    }
}