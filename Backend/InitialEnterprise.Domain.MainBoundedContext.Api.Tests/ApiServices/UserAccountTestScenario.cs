using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class UserAccountTestScenario : TestScenariosBase
    {
        [Test]
        public async Task Should_signin_status_code_ok()
        {
            var model = new UserLoginDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                RememberMe = false
            };

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateClient()
                    .PostAsync(Post.SignIn, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var siginResult = await DeserializeContentStringAsync<JObject>(response);
            var succeeded = (Boolean)siginResult[nameof(SignInResult.Succeeded)];

            Assert.IsTrue(succeeded);
        }

        [Test]
        public async Task Should_register_status_code_ok()
        {
            var model = new UserRegisterDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                ConfirmPassword = "#Az1234567890!",
                Username = "UpdatedName"
            };

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateClient()
                    .PostAsync(Post.Register, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var identityResult = await DeserializeContentStringAsync<JObject>(response);
            var succeeded = (Boolean)identityResult[nameof(IdentityResult.Succeeded)];

            Assert.IsTrue(succeeded);
        }

        [Test]
        public async Task Should_update_user_status_code_ok()
        {
            var model = new UserDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                ConfirmPassword = "#Az1234567890!",
                Username = "UpdatedName"
            };

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .PutAsync(Put.Update, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var identityResult = await DeserializeContentStringAsync<JObject>(response);
            var succeeded = (Boolean)identityResult[nameof(IdentityResult.Succeeded)];

            Assert.IsTrue(succeeded);
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