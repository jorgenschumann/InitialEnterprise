using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Tests.ApiControllers
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
                response = await server.CreateAuthClient()
                    .GetAsync(Get.GetIndex());

                response.EnsureSuccessStatusCode();
            }
        }
    }
}