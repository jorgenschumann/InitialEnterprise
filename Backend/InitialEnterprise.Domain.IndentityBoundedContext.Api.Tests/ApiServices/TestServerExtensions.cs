using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Services;
using InitialEnterprise.Shared.DataSeeding;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests.ApiServices
{
    public static class TestServerExtensions
    {
        public static HttpClient CreateClient(this TestServer server)
        {
            return server.CreateClient();
        }

        public static HttpClient CreateAuthenticatedClient(this TestServer server)
        {
            var tokenBuilder = server.Host.Services.GetService<IJwtSecurityTokenBuilder>();
            var token = tokenBuilder.CreateToken(SeedDataBuilder.BuildType<UserModule.Aggreate.ApplicationUser>());
            var client = server.CreateClient();
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
    }
}