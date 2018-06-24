using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class UpdateCurrencyIsoCodeCommand : DomainCommand
    {
        public string IsoCode { get; set; }

        public bool IsValid => true;
    }
}