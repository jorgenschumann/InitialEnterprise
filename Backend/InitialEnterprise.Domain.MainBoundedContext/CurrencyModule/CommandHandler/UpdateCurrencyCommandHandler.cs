using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.CommandHandler
{
    public class UpdateCurrencyCommandHandler : ICommandHandlerWithAggregateAsync<UpdateCurrencyCommand>
    {
        public async Task<IAggregateRoot> HandleAsync(UpdateCurrencyCommand currencyCommand)
        {
            await Task.CompletedTask;

            return null;
        }
    }
}