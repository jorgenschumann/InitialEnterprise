using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CreateCurrencyCommandValidationHandlerTests
    {
        [TestCaseSource(typeof(CurrencyCreateCommandTestCases))]
        public async Task Should_validate_CurrencyCreateCommand_return_valid_result(Tuple<bool, CurrencyCreateCommand> testCase)
        {
            //Arr
            var expectSuccess = testCase.Item1;
            var createCurrencyCommand = testCase.Item2;
            var createCurrencyCommandValidationHandler = new CreateCurrencyCommandValidationHandler();

            //Act
            var validationResult = createCurrencyCommandValidationHandler.Validate(testCase.Item2);

            //Assert
            Assert.IsTrue(validationResult.IsValid);
        }
    }

    internal class CurrencyCreateCommandTestCases : IEnumerable<Tuple<bool, CurrencyCreateCommand>>
    {
        public IEnumerator<Tuple<bool, CurrencyCreateCommand>> GetEnumerator()
        {
            yield return new Tuple<bool, CurrencyCreateCommand>(
                true, new CurrencyCreateCommand("British Pound", "GBP", 2, Guid.NewGuid()));

            yield return new Tuple<bool, CurrencyCreateCommand>(
              true, new CurrencyCreateCommand("Euro", "EUR", 3, Guid.NewGuid()));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}