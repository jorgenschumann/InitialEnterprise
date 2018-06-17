using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;


namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public class CreateCurrencyCommandHandler : 
        ICommandHandlerWithAggregateAsync<CreateCurrencyCommand>
    {
        private readonly CreateCurrencyCommandValidator<CreateCurrencyCommand> validator;

        public CreateCurrencyCommandHandler(CreateCurrencyCommandValidator<CreateCurrencyCommand> validator)
        {
            this.validator = validator;
        }

        public async Task<IAggregateRoot> HandleAsync(CreateCurrencyCommand command)
        {
            await Task.CompletedTask;

            return new Currency(command);
        }
    }
}
