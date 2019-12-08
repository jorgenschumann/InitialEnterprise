using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.CommandHandler;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterpriseTests.DataSeeding;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyCommandHanderTests
    {
        [Test]
        public async Task Should_handle_currencycreatecommand_return_commandhandleranswerAsync()
        {
            //Arrange
            var currencies = SeedDataBuilder.BuildTypeCollectionFromFile<Currency>();
            var mockCurrencyRepository = new Mock<ICurrencyRepository>();

            var mockCurrencyQuery = new Mock<CurrencyQuery>();
            mockCurrencyRepository.Setup(service => service.Query(mockCurrencyQuery.Object)).ReturnsAsync(currencies);

            var mockCreateValidationHandler = new MockValidator<CurrencyCreateCommand>();
            var mockUpdateValidationHandler = new MockValidator<CurrencyUpdateCommand>();

            var command = new CurrencyCreateCommand { Name = "British Pound", IsoCode = "GBP", Rate = 2 };  

            var currencyCommandHandler = new CurrencyCommandHandler(
                mockCurrencyRepository.Object,
                mockCreateValidationHandler.Object,
                mockUpdateValidationHandler.Object);
       
            //Act
            var commandHandlerAnswer = await currencyCommandHandler.HandleAsync(command);

            //Assert
            Assert.IsNotNull(commandHandlerAnswer);
        }

        [Test]
        public async Task Should_handle_currencyupdatecommand_return_commandhandleranswerasync()
        {
            //Arrange
            var currency = SeedDataBuilder.BuildTypeCollectionFromFile<Currency>().FirstOrDefault();
            var mockCurrencyRepository = new Mock<ICurrencyRepository>();

            mockCurrencyRepository.Setup(service => service.Query(It.IsAny<Guid>())).ReturnsAsync(currency);                 
          
            var mockCreateValidationHandler = new MockValidator<CurrencyCreateCommand>();
            var mockUpdateValidationHandler = new MockValidator<CurrencyUpdateCommand>();

            var command = new CurrencyUpdateCommand
            {
                Id = currency.Id,
                IsoCode = currency.IsoCode,
                Name = currency.Name,
                TimeStamp = DateTime.Now,
                UserId = currency.UserId
            };

            var currencyCommandHandler = new CurrencyCommandHandler(
                mockCurrencyRepository.Object,
                mockCreateValidationHandler.Object,
                mockUpdateValidationHandler.Object);

            //Act
            var commandHandlerAnswer = await currencyCommandHandler.HandleAsync(command);

            //Assert
            Assert.IsNotNull(commandHandlerAnswer);      
        }
    }

    public class MockValidator<T> : Mock<IValidator<T>> where T : class
    {
        //http://xml14x2.blogspot.com/2015/06/mock-collectionvalidator-using-moq-and.html

        public MockValidator()
        {
            Setup(x => x.Validate(It.IsAny<ValidationContext>())).Returns(new ValidationResult());          
        }
    }
}