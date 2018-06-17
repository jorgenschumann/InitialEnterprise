using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public class UpdateIsoCodeCurrencyCommandHandler :
        ICommandHandlerWithAggregateAsync<UpdateCurrencyIsoCodeCommand>
    {
        public async Task<IAggregateRoot> HandleAsync(UpdateCurrencyIsoCodeCommand currencyCommand)
        {
            await Task.CompletedTask;

            return null;
        }
    }
}