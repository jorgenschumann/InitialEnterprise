using InitialEnterprise.Shared.Dtos;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class AuthenticationTestScenario : TestScenariosBase
    {
        public const string ApiUrlBase = "api/authentication";

        private static class Post
        {
            public static string SignIn = $"{ApiUrlBase}/signin";

            public static string Register = $"{ApiUrlBase}/register";                 
        }      
      
        [Test, Order(1)]
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
            var succeeded = (Boolean)siginResult["signInResult"]["succeeded"];

            Assert.IsTrue(succeeded);
        }

        [Test, Order(2)]
        public async Task Should_register_status_code_ok()
        {
            var model = new UserRegisterDto
            {
                FirstName = "Jorgen",
                LastName = "Schumann",
                DateOfBirth = new DateTime(1968, 11, 30),
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
            var succeeded = (Boolean)identityResult["succeeded"];

            Assert.IsTrue(succeeded);
        }
        
        [Test, Order(3)]
        public async Task Should_register_user_status_code_ok()
        {
            var model = new UserRegisterDto
            {
                FirstName = "Neil",
                LastName = "Armstrong",
                DateOfBirth = new DateTime(1930, 08, 05),
                Email = "Neil.Armstrong@test.de",
                Password = "#Az1234567890!",
                ConfirmPassword = "#Az1234567890!",
                Username = "NArmstrong"
            };

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .PostAsync(Post.Register, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var identityResult = await DeserializeContentStringAsync<JObject>(response);
            var succeeded = (Boolean)identityResult["succeeded"];

            Assert.IsTrue(succeeded);
        }
    }
}