using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using System;
using Xunit;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
   
    public class CurrencyAggTests
    {
        [Fact(DisplayName = nameof(Check_ctor_is_private))]
        public void Check_ctor_is_private()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<MissingMethodException>(() =>
            {
                Activator.CreateInstance(typeof(Currency));  //todo:dynamic by refelection (AggregateRoot)
            });
        }

        [Fact(DisplayName = nameof(Should_create_entity_with_command_by_private_ctor))]
        public void Should_create_entity_with_command_by_private_ctor()
        {
            //Arrange
            var createCommand = new CurrencyCreateCommand
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