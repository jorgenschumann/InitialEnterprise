using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.DDD.Decorators
{
    public class ValidationCommandHandlerDecorator<TCommand> :ICommandHandlerWithAggregateAsync<TCommand> where TCommand : IDomainCommand
    {
        private readonly ICommandHandlerWithAggregateAsync<TCommand> decoratee;

        public ValidationCommandHandlerDecorator(ICommandHandlerWithAggregateAsync<TCommand> decoratedHandler)
        {
            decoratee = decoratedHandler;
        }

        public async Task<IAggregateRoot> HandleAsync(TCommand command)
        {
            return await decoratee.HandleAsync(command);
        }
    }
}