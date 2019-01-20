﻿using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    public static class TestServerExtensions
    {
        public static HttpClient CreateClient(this TestServer server)
        {
            return server.CreateClient();
        }

        public static HttpClient CreateAuthenticatedClient(this TestServer server)
        {
            var tokenBuilder = server.Host.GetService<IJwtSecurityTokenBuilder>();
            var token = tokenBuilder.CreateToken(SeedDataBuilder.BuildType<ApplicationUser>());
            var client = server.CreateClient();
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
    }
}