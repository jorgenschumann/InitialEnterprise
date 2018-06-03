using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CreateCurrencyCommand: ICommand
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
}
