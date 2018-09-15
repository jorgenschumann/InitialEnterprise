using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CurrencyUpdateRateCommand : DomainCommand
    {     

        public bool IsValid => true;
    }
}