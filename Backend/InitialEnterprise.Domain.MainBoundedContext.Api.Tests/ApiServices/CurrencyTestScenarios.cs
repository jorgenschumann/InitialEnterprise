using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.Application;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests
{
    public class CurrencyTestScenarios : CurrencyTestScenariosBase
    {
        private const string directory = "ApiServices";

        [Fact]
        public async Task Post_currency_and_response_ok_status_code()
        {
            using (var server = base.CreateServer(directory))
            {
                var response = await server.CreateClient()
                   .PostAsync(Post.Currency, 
                   BuildContentString(new BaseDataTransferObject
                   {
                       UserId = 12
                   }));

                response.EnsureSuccessStatusCode();
            }
        }        
    }
}