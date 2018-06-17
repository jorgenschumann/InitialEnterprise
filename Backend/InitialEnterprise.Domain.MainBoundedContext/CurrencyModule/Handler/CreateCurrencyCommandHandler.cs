using System.Threading.Tasks;
using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;


namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public class CreateCurrencyCommandHandler : ICommandHandlerWithAggregateAsync<CreateCurrencyCommand>
    {
        public async Task<IAggregateRoot> HandleAsync(CreateCurrencyCommand command)
        {
            await Task.CompletedTask;

            return new Currency(command);
        }

    }
}
