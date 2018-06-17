using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class Currency : BaseEntity
    {
        public string Name { get; private set; }

        public string IsoCode { get; private set; }

        public decimal Rate { get; private set; }
        
        public Currency()
        {
        }

        public Currency(CreateCurrencyCommand createCommand)
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
