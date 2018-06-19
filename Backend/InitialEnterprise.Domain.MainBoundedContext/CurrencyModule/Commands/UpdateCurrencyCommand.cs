﻿using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class UpdateCurrencyCommand : DomainCommand, IInjectable
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public decimal Rate { get; set; }

        public bool IsValid => true;
    }
}