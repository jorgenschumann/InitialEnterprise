using AgileObjects.AgileMapper;
using DeepEqual.Syntax;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterpriseTests.DataSeeding;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    [TestFixture]
    public partial class CurrencyTestScenario : TestScenariosBase
    {
        [Test]
        public async Task Get_all_currencies_response_ok_status_code()
        {
            var currencies = SeedDataBuilder.BuildTypeCollectionFromFile<CurrencyDto>();
       
            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .GetAsync(Get.GetCurrencies());

                response.EnsureSuccessStatusCode();
            }

            var returned = await DeserializeContentStringAsync<IEnumerable<CurrencyDto>>(response);

            Assert.True(currencies.Count() == returned.Count());           
        }

        [Test]
        public async Task Get_currency_response_ok_status_code()
        {
            var currency = SeedDataBuilder.BuildType<CurrencyDto>();
            var expectedCurrencyDto = Mapper.Map(currency).ToANew<CurrencyDto>();

            HttpResponseMessage response;
            var server = CreateServer(directory);
            {
                response = await server.CreateAuthenticatedClient()
                    .GetAsync(Get.GetCurrency(currency.Id));

                response.EnsureSuccessStatusCode();
            }

            var currencyDto = await DeserializeContentStringAsync<CurrencyDto>(response);

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
            var server = CreateServer(directory);
            response = await server.CreateAuthenticatedClient()
                .PostAsync(Post.Currency, SerializeContentString(currencyDto));

            response.EnsureSuccessStatusCode();

            var answer =
                JsonConvert.DeserializeObject<CommandHandlerAnswerDto<CurrencyDto>>(
                await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(answer.ValidationResult);
            Assert.IsEmpty(answer.ValidationResult.Errors);
            Assert.IsNotNull(answer.AggregateRoot);           
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
            var server = CreateServer(directory);
            response = await server.CreateAuthenticatedClient()
               .PostAsync(Post.Currency,
                   SerializeContentString(newCurrencyDto));

            var answer = await DeserializeContentStringAsync<CommandHandlerAggregateAnswer>(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.IsNotNull(answer.ValidationResult);
            Assert.IsNotEmpty(answer.ValidationResult.Errors);
        }
    }
}