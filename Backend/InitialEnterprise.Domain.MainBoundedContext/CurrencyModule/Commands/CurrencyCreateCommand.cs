using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CurrencyCreateCommand : DomainCommand
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public decimal Rate { get; set; }
    }
}