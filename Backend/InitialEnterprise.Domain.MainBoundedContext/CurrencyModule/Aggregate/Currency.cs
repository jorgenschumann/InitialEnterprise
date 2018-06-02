﻿using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class Currency : BaseEntity
    {
        public string Name { get; private set; }

        public string IsoCode { get; private set; }

        public decimal Rate { get; private set; }

        public Currency(ICommand createCommand)
        {

        }
      
    }
}
