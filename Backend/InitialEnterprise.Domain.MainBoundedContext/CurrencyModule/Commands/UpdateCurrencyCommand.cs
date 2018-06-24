using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class UpdateCurrencyCommand : DomainCommand
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public decimal Rate { get; set; }

        public bool IsValid => true;
    }
}