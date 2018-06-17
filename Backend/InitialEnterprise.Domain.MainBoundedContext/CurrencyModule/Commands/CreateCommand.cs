using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CreateCurrencyCommand: DomainCommand, IInjectable
    {
        public string Name { get;  set; }

        public string IsoCode { get;  set; }

        public decimal Rate { get;  set; }

        public bool IsValid => true;

        public object Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class UpdateRateCommand : DomainCommand, IInjectable
    {
        public decimal Rate { get; set; }

        public bool IsValid => true;
    }

    public class UpdateIsoCodeCommand : DomainCommand, IInjectable
    {
        public string IsoCode { get; set; }

        public bool IsValid => true;
    }
}
