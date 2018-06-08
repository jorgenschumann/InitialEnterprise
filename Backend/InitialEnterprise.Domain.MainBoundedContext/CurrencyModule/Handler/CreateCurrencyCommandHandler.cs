using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public  class CreateCurrencyCommandHandler: ICommandHandler<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository currencyRepository;
        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public void Handle(CreateCurrencyCommand command)
        {
            var currency = new Currency(command);        

            currencyRepository.Save(currency);
        }
    }
}
