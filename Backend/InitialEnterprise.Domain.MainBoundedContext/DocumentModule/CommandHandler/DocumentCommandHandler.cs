using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.CommandHandler
{
    public class DocumentCommandHandler :
        ICommandHandlerWithResultAsync<DocumentCreateCommand>,
        ICommandHandlerWithResultAsync<DocumentUpdateCommand>
    {

        private readonly IDocumentRepository documentRepository;
        private readonly IValidator<DocumentCreateCommand> createValidationHandler;
        private readonly IValidator<DocumentUpdateCommand> updateValidationHandler;

        public DocumentCommandHandler(IDocumentRepository documentRepository,
           IValidator<DocumentCreateCommand> createValidationHandler,
           IValidator<DocumentUpdateCommand> updateValidationHandler)
        {
            this.documentRepository = documentRepository;
            this.updateValidationHandler = updateValidationHandler;
            this.createValidationHandler = createValidationHandler;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(DocumentUpdateCommand command)
        {
            var currency = await documentRepository.Query(command.Id);
            var commandHandlerAnswer = new CommandHandlerAggregateAnswer
            {
                ValidationResult = this.updateValidationHandler.Validate(command)
            };

            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                commandHandlerAnswer.AggregateRoot =
                    documentRepository.Update(currency.Update(command));
            }
            return commandHandlerAnswer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(DocumentCreateCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAggregateAnswer
            {
                ValidationResult = this.createValidationHandler.Validate(command)
            };

            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                commandHandlerAnswer.AggregateRoot =
                    await documentRepository.Insert(new Document(command));
            }
            return commandHandlerAnswer;
        }
    }
}
