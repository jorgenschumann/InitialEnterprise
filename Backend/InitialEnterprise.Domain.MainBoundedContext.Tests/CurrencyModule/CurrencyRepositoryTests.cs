using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

using Moq.EntityFrameworkCore;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyRepositoryTests
    {
        [Test]
        public async Task Should_return_all_currencies()
        {
            //Arrange
            IList<Currency> currencies = SeedDataBuilder.BuildTypeCollectionFromFile<Currency>() as IList<Currency>;
            var mockCurrencyQuery = new Mock<CurrencyQuery>();

            var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            var mockDbContext = new Mock<MainDbContext>(optionsBuilder.Options);
            mockDbContext.Setup(x => x.Currency).ReturnsDbSet(currencies);

            ICurrencyRepository currencyRepository = new CurrencyRepository(mockDbContext.Object);

            //Act
            var currencyQueryResult = await currencyRepository.Query(new CurrencyQuery());

            //Assert
            Assert.AreEqual(currencies.Count(), currencyQueryResult.Count());
        }

        [Test]
        public async Task Should_return_all_currency_by_currencyid()
        {
            //Arrange
            IList<Currency> currencies = SeedDataBuilder.BuildTypeCollectionFromFile<Currency>() as IList<Currency>;
            var currencyQuery = currencies[0].Id;

            var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            var mockDbContext = new Mock<MainDbContext>(optionsBuilder.Options);
            mockDbContext.Setup(x => x.Currency).ReturnsDbSet(currencies);

            ICurrencyRepository currencyRepository = new CurrencyRepository(mockDbContext.Object);

            //Act
            var currencyQueryResult = await currencyRepository.Query(currencyQuery);

            //Assert
            Assert.AreEqual(currencies[0], currencyQueryResult);
        }
    }
}