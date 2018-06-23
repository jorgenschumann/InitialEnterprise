using System;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyAggTests
    {
        [Fact]
        public void Check_That_Ctor_Is_Protected()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<MissingMethodException>(() => { Activator.CreateInstance(typeof(Currency)); });
        }

        [Fact]
        public void Should_Create_Entity_With_Command_Over_Protected_Ctor()
        {
            //Arrange
            var createCommand = new CreateCurrencyCommand
            {
                Name = "British Pound",
                IsoCode = "GBP",
                Rate = 1
            };

            //Act
            var activatedCurrency = Activator.CreateInstance(typeof(Currency), createCommand);

            //Assert
            Assert.NotNull(activatedCurrency);
        }
    }
}