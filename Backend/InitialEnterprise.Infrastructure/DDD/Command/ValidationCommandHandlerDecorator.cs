using System.Threading.Tasks;
using FluentValidation;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.DDD.Command
{
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandlerWithAggregateAsync<TCommand> where TCommand : IDomainCommand
    {
        private readonly IValidator<TCommand> validator;
        private readonly ICommandHandlerWithAggregateAsync<TCommand> decoratee;

        public ValidationCommandHandlerDecorator(IValidator<TCommand> validator, ICommandHandlerWithAggregateAsync<TCommand> decoratedHandler)
        {
            this.validator = validator;
            this.decoratee = decoratedHandler;
        }

        public async Task<IAggregateRoot> HandleAsync(TCommand command)
        {
            var result = this.validator.Validate(command);

            return await this.decoratee.HandleAsync(command);
        }
    }
}