using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
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
                   BuildContentString(new CurrencyDto
                   {
                       UserId = 12, IsoCode = "GBP", Id = Guid.NewGuid(), Name = "British Pound", Rate = "1.327898"
                   }));

                response.EnsureSuccessStatusCode();
            }
        }        
    }
}