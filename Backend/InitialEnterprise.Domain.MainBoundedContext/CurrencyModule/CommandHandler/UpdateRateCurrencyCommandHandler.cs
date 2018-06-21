using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public class UpdateRateCurrencyCommandHandler :
        ICommandHandlerWithAggregateAsync<UpdateCurrencyRateCommand>
    {
        public async Task<IAggregateRoot> HandleAsync(UpdateCurrencyRateCommand currencyCommand)
        {
            await Task.CompletedTask;

            return null;
        }
    }
}