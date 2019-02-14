using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.CommandHandler;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterpriseTests.DataSeeding;
using Moq;
using NUnit.Framework;
using System;
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
            var mockCreateValidationHandler = new Mock<IValidator<CurrencyCreateCommand>>();
            var mockUpdateValidationHandler = new Mock<IValidator<CurrencyUpdateCommand>>();

            mockCreateValidationHandler.Setup(handler => handler.Validate(null));
            mockUpdateValidationHandler.Setup(handler => handler.Validate(null));
            mockCurrencyRepository.Setup(service => service.Query(mockCurrencyQuery.Object)).ReturnsAsync(currencies);

            var currencyCommandHandler = new CurrencyCommandHandler(
                mockCurrencyRepository.Object, mockCreateValidationHandler.Object, mockUpdateValidationHandler.Object);

            var createCommand = new CurrencyCreateCommand("British Pound", "GBP", 1, Guid.NewGuid());

            //Act
            var commandHandlerAnswer = await currencyCommandHandler.HandleAsync(createCommand);

            //Assert
            Assert.IsNotNull(commandHandlerAnswer);
        }

        [Test]
        public async Task Should_handle_currencyupdatecommand_return_commandhandleranswerasync()
        {
            //Arrange
            var currency = SeedDataBuilder.BuildType<Currency>();
            var mockCurrencyRepository = new Mock<ICurrencyRepository>();
            var mockCreateValidationHandler = new Mock<IValidator<CurrencyCreateCommand>>();
            var mockUpdateValidationHandler = new Mock<IValidator<CurrencyUpdateCommand>>();

            mockCreateValidationHandler.Setup(handler => handler.Validate(null));
            mockUpdateValidationHandler.Setup(handler => handler.Validate(null));
            mockCurrencyRepository.Setup(x => x.Query(It.IsAny<Guid>())).Returns(Task.FromResult(currency));

            var currencyCommandHandler = new CurrencyCommandHandler(
                mockCurrencyRepository.Object, mockCreateValidationHandler.Object, mockUpdateValidationHandler.Object);

            var command = new CurrencyUpdateCommand
            {
                Id = Guid.NewGuid(),
                IsoCode = "GBP",
                Name = "British Pound",
                TimeStamp = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            //Act
            var commandHandlerAnswer = await currencyCommandHandler.HandleAsync(command);

            //Assert
            Assert.IsNotNull(commandHandlerAnswer);
        }
    }
}