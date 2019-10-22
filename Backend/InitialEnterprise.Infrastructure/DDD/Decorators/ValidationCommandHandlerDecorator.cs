using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.DDD.Decorators
{
    public class ValidationCommandHandlerDecorator<TCommand> :ICommandHandlerWithResultAsync<TCommand> where TCommand : IDomainCommand
    {
        private readonly ICommandHandlerWithResultAsync<TCommand> decoratee;

        public ValidationCommandHandlerDecorator(ICommandHandlerWithResultAsync<TCommand> decoratedHandler)
        {
            decoratee = decoratedHandler;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(TCommand command)
        {
            return await decoratee.HandleAsync(command);
        }
    }
}