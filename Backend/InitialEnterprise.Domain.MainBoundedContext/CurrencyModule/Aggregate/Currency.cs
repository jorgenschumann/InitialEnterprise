using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class Currency : BaseEntity
    {
        public string Name { get; private set; }

        public string IsoCode { get; private set; }

        public decimal Rate { get; private set; }
        
        private Currency()
        {
        }

        public Currency(CreateCommand createCommand)
        {
            if (createCommand.IsValid)
            {
                Name = createCommand.Name;
                IsoCode = createCommand.IsoCode;
                Rate = createCommand.Rate;
            }
        }      
    }
}
