using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.Application;
using Newtonsoft.Json;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests
{
    public class CurrencyTestScenarios : CurrencyTestScenariosBase
    {
        private const string directory = "ApiServices";

        [Fact]
        public async Task Post_currency_and_response_ok_status_code()
        {
            using (var server = CreateServer(directory))
            {
                var content = new StringContent(BuildBlueApleModel(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                   .PostAsync(Post.Currency, content);

                response.EnsureSuccessStatusCode();
            }
        }

        string BuildBlueApleModel()
        {
            var model = new BaseDataTransferObject { UserId = 12 };
            return JsonConvert.SerializeObject(model);
        }
    }
}