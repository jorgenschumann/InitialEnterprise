using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class HomeTestScenario : TestScenariosBase
    {
        [Test]
        public async Task Get_home_swagger_ok_status_code()
        {
            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateClient()
                    .GetAsync(Get.Index());

                response.EnsureSuccessStatusCode();
            }
        }
    }
}