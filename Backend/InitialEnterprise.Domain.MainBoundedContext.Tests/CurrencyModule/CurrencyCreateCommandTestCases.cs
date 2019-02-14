using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Tests.CurrencyModule
{
    internal class CurrencyCreateCommandTestCases : IEnumerable<Tuple<bool, CurrencyCreateCommand>>
    {
        public IEnumerator<Tuple<bool, CurrencyCreateCommand>> GetEnumerator()
        {
            yield return new Tuple<bool, CurrencyCreateCommand>(
                true, new CurrencyCreateCommand(
                    "British Pound", "GBP", 2, Guid.NewGuid()));

            yield return new Tuple<bool, CurrencyCreateCommand>(
              true, new CurrencyCreateCommand(
                  "Euro", "EUR", 3, Guid.NewGuid()));

            yield return new Tuple<bool, CurrencyCreateCommand>(
                false, new CurrencyCreateCommand(
                    "", "EUR", 3, Guid.NewGuid()));

            yield return new Tuple<bool, CurrencyCreateCommand>(
                false, new CurrencyCreateCommand(
                    "Euro", "", 3, Guid.NewGuid()));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}