using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CurrencyCreateCommand : DomainCommand
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public decimal Rate { get; set; }

        public CurrencyCreateCommand(string name, string isoCode, decimal rate, Guid userId)
        {
            Name = name;
            IsoCode = isoCode;
            Rate = rate;
            UserId = userId;
            TimeStamp = DateTime.Now;
        }
    }
}