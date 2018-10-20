using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.CommandHandler
{
    public class PersonCommandHandler
        : ICommandHandlerWithResultAsync<CreatePersonCommand>,
          ICommandHandlerWithResultAsync<UpdatePersonCommand>
    {
        private readonly IPersonRepository personRepository;
        private readonly IValidator<CreatePersonCommand> createValidationHandler;
        private readonly IValidator<UpdatePersonCommand> updateValidationHandler;

        public PersonCommandHandler(
            IPersonRepository personRepository,
            IValidator<CreatePersonCommand> createValidationHandler,
            IValidator<UpdatePersonCommand> updateValidationHandler)
        {
            this.personRepository = personRepository;
            this.createValidationHandler = createValidationHandler;
            this.updateValidationHandler = updateValidationHandler;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(CreatePersonCommand command)
        {
            return new CommandHandlerAnswer
            {
                ValidationResult = this.createValidationHandler.Validate(command),
                AggregateRoot = await personRepository.Insert(new Person(command))
            };
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(UpdatePersonCommand command)
        {
            var answer = new CommandHandlerAnswer();

            var person = await personRepository.Query(command.Id);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.updateValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Update(command));
                }               
            }
            return answer;
        }
    }
}