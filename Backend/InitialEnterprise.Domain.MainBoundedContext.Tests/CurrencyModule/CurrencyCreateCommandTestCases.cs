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
                true, new CurrencyCreateCommand { Name= "British Pound", IsoCode= "GBP", Rate=2 });

            yield return new Tuple<bool, CurrencyCreateCommand>(
             true, new CurrencyCreateCommand { Name = "Euro", IsoCode = "EUR", Rate = 3 });

            yield return new Tuple<bool, CurrencyCreateCommand>(
                    true, new CurrencyCreateCommand { Name = "", IsoCode = "EUR", Rate = 3 });

            yield return new Tuple<bool, CurrencyCreateCommand>(
                  true, new CurrencyCreateCommand { Name = "Euro", IsoCode = "", Rate = 3 });        
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}