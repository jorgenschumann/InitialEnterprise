using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.CommandHandler
{
    public class CurrencyCommandHandler :
        ICommandHandlerWithResultAsync<CurrencyCreateCommand>,
        ICommandHandlerWithResultAsync<CurrencyUpdateCommand>
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IValidator<CurrencyCreateCommand> createValidationHandler;
        private readonly IValidator<CurrencyUpdateCommand> updateValidationHandler;

        public CurrencyCommandHandler(ICurrencyRepository currencyRepository,
            IValidator<CurrencyCreateCommand> createValidationHandler,
            IValidator<CurrencyUpdateCommand> updateValidationHandler)
        {
            this.currencyRepository = currencyRepository;
            this.updateValidationHandler = updateValidationHandler;
            this.createValidationHandler = createValidationHandler;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CurrencyCreateCommand command)
        {      
            var commandHandlerAnswer = new CommandHandlerAggregateAnswer
            {
                ValidationResult = this.createValidationHandler.Validate<CurrencyCreateCommand>(command)
            };

            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                commandHandlerAnswer.AggregateRoot =
                    await currencyRepository.Insert(new Currency(command));
            }
            return commandHandlerAnswer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CurrencyUpdateCommand command)
        {
            var currency = await currencyRepository.Query(command.Id);
            var commandHandlerAnswer = new CommandHandlerAggregateAnswer
            {
                ValidationResult = this.updateValidationHandler.Validate<CurrencyUpdateCommand>(command)
            };

            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                commandHandlerAnswer.AggregateRoot =
                    currencyRepository.Update(currency.Update(command));
            }
            return commandHandlerAnswer;
        }
    }
}