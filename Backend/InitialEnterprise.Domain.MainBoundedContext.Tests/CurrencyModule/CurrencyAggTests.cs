using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Misc;
using NUnit.Framework;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CurrencyAggTests
    {
        [Test]
        public void Check_ctor_is_private()
        {
            //Arrange
            var candidateTypes = ReflectionUtils.GetAllDerivedTypes(
                AppDomain.CurrentDomain,
                    new[] { typeof(AggregateRoot), typeof(Entity) });

            //Act

            //Assert

            foreach (var candidate in candidateTypes)
            {
                Assert.Throws<MissingMethodException>(() =>
                {
                    Activator.CreateInstance(candidate);
                });
            }
        }

        [Test]
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