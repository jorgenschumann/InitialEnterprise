using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.CommandHandler
{
    public class CreateCurrencyCommandHandler : ICommandHandlerWithAggregateAsync<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository currencyRepository;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<IAggregateRoot> HandleAsync(CreateCurrencyCommand command)
        {
            var currency = new Currency(command);

            return await this.currencyRepository.Insert(currency);
        }
    }
}