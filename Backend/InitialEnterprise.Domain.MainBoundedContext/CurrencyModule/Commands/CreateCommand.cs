using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class CreateCommand: ICommand
    {
        public string Name { get;  set; }

        public string IsoCode { get;  set; }

        public decimal Rate { get;  set; }

        public object Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
