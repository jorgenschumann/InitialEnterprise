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

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyRepositoryTests
    {
        //https://docs.microsoft.com/de-de/ef/ef6/fundamentals/testing/mocking

        [Test]
        public async Task Should_return_currency_by_currencyid()
        {
            //Arrange
            IQueryable<Currency> currencies = SeedDataBuilder.BuildTypeCollectionFromFile<Currency>().AsQueryable();
            var mockCurrencyQuery = new Mock<CurrencyQuery>();

            var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            var mockDbContext = new Mock<IMainDbContext>();

            var mockSet = new Mock<DbSet<Currency>>();
            mockSet.As<IQueryable<Currency>>().Setup(m => m.Provider).Returns(currencies.Provider);
            mockSet.As<IQueryable<Currency>>().Setup(m => m.Expression).Returns(currencies.Expression);
            mockSet.As<IQueryable<Currency>>().Setup(m => m.ElementType).Returns(currencies.ElementType);
            mockSet.As<IQueryable<Currency>>().Setup(m => m.GetEnumerator()).Returns(currencies.GetEnumerator());

            mockDbContext.Setup(c => c.Currency).Returns(mockSet.Object);

            ICurrencyRepository currencyRepository = new CurrencyRepository(mockDbContext.Object);

            //Act
            var currencyQueryResult = await currencyRepository.Query(new CurrencyQuery());

            //Assert
        }
    }
}