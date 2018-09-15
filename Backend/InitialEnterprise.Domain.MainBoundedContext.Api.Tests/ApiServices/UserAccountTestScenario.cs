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
        public async Task Should_SignIn_status_code_ok()//(string email, string password, bool assertIsTrue)
        {    
            var model = new SignInDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                RememberMe = false
            };

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient().PostAsync(Post.SignIn, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var siginResult = DeserializeContentString<JObject>(response);
            var succeeded = (Boolean)siginResult[nameof(SignInResult.Succeeded)];
                       
            Assert.IsTrue(succeeded);    
        }

        [Test]
        public async Task Should_Register_status_code_ok()
        {
            var model = new UserRegisterDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                ConfirmPassword = "#Az1234567890!",
                Username = "UpdatedName"
            };

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient().PostAsync(Post.Register, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var identityResult = DeserializeContentString<JObject>(response);
            var succeeded = (Boolean)identityResult[nameof(IdentityResult.Succeeded)];

            Assert.IsTrue(succeeded);
        }

        [Test]
        public async Task Should_Update_User_status_code_ok()
        {
            var model = new UserDto
            {
                Email = "User1@test.de",
                Password = "#Az1234567890!",
                ConfirmPassword = "#Az1234567890!",
                Username = "UpdatedName"
            };

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient().PutAsync(Put.Update, SerializeContentString(model));

                response.EnsureSuccessStatusCode();
            }
            var identityResult = DeserializeContentString<JObject>(response);
            var succeeded = (Boolean)identityResult[nameof(IdentityResult.Succeeded)];

            Assert.IsTrue(succeeded);
        }

        [Test]
        public async Task Should_Get_User_By_Given_Id_status_code_ok()
        {
            var requestedUserId = SeedDataBuilder.BuildTypeCollectionFromFile<ApplicationUser>().First();

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient().GetAsync(Get.UserBy(requestedUserId.Id));

                response.EnsureSuccessStatusCode();
            }
            var userResult = DeserializeContentString<JObject>(response);
            
            Assert.IsNotNull(userResult);
        }


        [Test]
        public async Task Should_Get_All_User_By_Given_Empty_Query_status_code_ok()
        {
            var query = new UserQuery();   

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient().PostAsync(Post.Query,SerializeContentString(query));

                response.EnsureSuccessStatusCode();
            }
            var userResult = DeserializeContentString<IEnumerable<ApplicationUser>>(response);

            Assert.IsNotNull(userResult);
        }
    }
}