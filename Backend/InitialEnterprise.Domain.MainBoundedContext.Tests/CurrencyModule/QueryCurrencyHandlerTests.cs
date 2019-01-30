using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterpriseTests.DataSeeding;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyQueryHandlerTests
    {
        [Test]
        public async Task Should_handle_currencyquery_return_currency()
        {
            //Arrange
            var currency = SeedDataBuilder.BuildType<Currency>();
            var mockCurrencyQuery = new Mock<CurrencyQuery>();
            var mockCurrencyRepository = new Mock<ICurrencyRepository>();
            mockCurrencyRepository.Setup(service => service.Query(It.IsAny<Guid>())).ReturnsAsync(currency);

            var currencyQueryHandler = new QueryCurrencyHandlerAsync(mockCurrencyRepository.Object);

            //Act
            var returnedCurrency = await currencyQueryHandler.RetrieveAsync(mockCurrencyQuery.Object);

            //Assert
            Assert.IsNotNull(returnedCurrency);
        }
    }
}