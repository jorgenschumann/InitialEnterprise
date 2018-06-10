using System.Linq;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Testfixture;
using Moq;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyServiceTests
    {
       
        [Fact]
        public void Should_Save_Created_Currency()
        {
            //Arr
            var expected = TestdataFactory.Currencies().First();
            var mockRepository = new Mock<ICurrencyRepository>();
            mockRepository.Setup(x => x.Update(expected)).Returns(expected);
            
            var currencyService = new CurrencyService(mockRepository.Object);

            //Act      
            var actual = currencyService.Save(expected);

            //Assert
            Assert.Same(expected, actual);
        
        }
    }
}
