using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler;
using NUnit.Framework;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    public class CreateCurrencyCommandValidationHandlerTests
    {
        [TestCaseSource(typeof(CurrencyCreateCommandTestCases))]
        public void Should_validate_currencycreatecommand_return_result(Tuple<bool, CurrencyCreateCommand> testCase)
        {
            //Arr
            var expectSuccess = testCase.Item1;
            var createCurrencyCommand = testCase.Item2;
            var createCurrencyCommandValidationHandler = new CreateCurrencyCommandValidationHandler();

            //Act
            var validationResult = createCurrencyCommandValidationHandler.Validate(testCase.Item2);

            //Assert
            Assert.AreEqual(validationResult.IsValid, testCase.Item1);
        }
    }
}