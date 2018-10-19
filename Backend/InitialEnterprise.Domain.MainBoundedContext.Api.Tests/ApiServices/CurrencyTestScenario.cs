using AgileObjects.AgileMapper;
using DeepEqual.Syntax;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterpriseTests.DataSeeding;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class CurrencyTestScenario : TestScenariosBase
    {        
        [Test]
        public async Task Get_currency_response_ok_status_code()
        {                
            var currency = SeedDataBuilder.BuildType<Currency>();
            var expectedCurrencyDto = Mapper.Map(currency).ToANew<CurrencyDto>();

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            { 
                response = await server.CreateAuthClient()
                    .GetAsync(Get.GetCurrency(currency.Id));

                response.EnsureSuccessStatusCode();
            }

            var currencyDto = DeserializeContentString<CurrencyDto>(response);
            
            Assert.IsNotNull(currencyDto); 
            Assert.True(currencyDto.IsDeepEqual(expectedCurrencyDto));
        }

        [Test]
        public async Task Post_currency_response_ok_status_code()
        {
            var currencyDto = new CurrencyDto
            {
                UserId = Guid.NewGuid(),
                IsoCode = "EUR",
                Id = Guid.NewGuid(),
                Name = "Euro",
                Rate = "1.327898"
            };

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateAuthClient()                  
                    .PostAsync(Post.Currency, SerializeContentString(currencyDto));

                response.EnsureSuccessStatusCode();
            }

            var answer =
                JsonConvert.DeserializeObject<CommandHandlerAnswerDto<CurrencyDto>>(
                await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(answer.ValidationResult);
            Assert.IsEmpty(answer.ValidationResult.Errors);
            Assert.IsNotNull(answer.AggregateRoot);
            Assert.IsNotEmpty(answer.AggregateRoot.Events);
        }

        [Test]
        public async Task Post_currency_response_validation_error_status_code_ok()
        {
            var newCurrencyDto = new CurrencyDto
            {
                UserId = Guid.NewGuid(),
                IsoCode = "MORE_THEN_3",
                Id = Guid.NewGuid(),
                Name = "B",
                Rate = "1.327898"
            };

            HttpResponseMessage response;
            using (var server = CreateServer(directory))
            {
                response = await server.CreateAuthClient()                   
                   .PostAsync(Post.Currency,
                       SerializeContentString(newCurrencyDto));

                response.EnsureSuccessStatusCode();
            }

            var answer = DeserializeContentString<CommandHandlerAnswer>(response);

            Assert.IsNotNull(answer.ValidationResult);
            Assert.IsNotEmpty(answer.ValidationResult.Errors);
        }
    }
}