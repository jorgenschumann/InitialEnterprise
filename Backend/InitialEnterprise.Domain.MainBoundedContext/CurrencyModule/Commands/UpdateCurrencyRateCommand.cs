using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class UpdateCurrencyRateCommand : DomainCommand
    {
        public decimal Rate { get; set; }

        public bool IsValid => true;
    }
}