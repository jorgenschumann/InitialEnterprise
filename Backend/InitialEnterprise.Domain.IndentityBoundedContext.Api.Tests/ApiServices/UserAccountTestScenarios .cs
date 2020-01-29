using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Queries;
using InitialEnterprise.Shared.DataSeeding;
using InitialEnterprise.Shared.Dtos;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class UserAccountTestScenarios : TestScenariosBase
    {
        public const string ApiUrlBase = "api/UserAccount";

        private static class Get
        {
            public static string UserBy(Guid id) => $"{ApiUrlBase}/{id}";
        }

        private static class Post
        {       
          
            public static string Query = $"{ApiUrlBase}";
        }

        private static class Put
        {
            public static string Update = $"{ApiUrlBase}";
        }

        [Test]
        public async Task Should_get_user_by_given_id_status_code_ok()
        {
            var requestedUserId = SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUser>().First();

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .GetAsync(Get.UserBy(requestedUserId.Id));

                response.EnsureSuccessStatusCode();
            }
            var userResult = await DeserializeContentStringAsync<JObject>(response);

            Assert.IsNotNull(userResult);
        }

        [Test]
        public async Task Should_get_all_users_by_given_empty_query_status_code_ok()
        {
            var query = new UserQuery();

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .PostAsync(Post.Query, SerializeContentString(query));

                response.EnsureSuccessStatusCode();
            }
            var userResult = await DeserializeContentStringAsync<IEnumerable<ApplicationUser>>(response);

            Assert.IsTrue(userResult.Any());
        }
    }
}