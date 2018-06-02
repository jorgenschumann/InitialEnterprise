﻿using System.Linq;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Testfixture;
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
            var currencyService = new CurrencyService();

            //Act      
            var actual = currencyService.Save(expected);

            //Assert
            Assert.Same(expected, actual);
        
        }
    }
}
