using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
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
        : ICommandHandlerWithResultAsync<PersonCreateCommand>,
          ICommandHandlerWithResultAsync<PersonUpdateCommand>,
          ICommandHandlerWithResultAsync<EmailAddressDeleteCommand>,
          ICommandHandlerWithResultAsync<EmailAddressCreateCommand>,
          ICommandHandlerWithResultAsync<EmailAddressUpdateCommand>,
          ICommandHandlerWithResultAsync<AddressDeleteCommand>,
          ICommandHandlerWithResultAsync<AddressUpdateCommand>,
          ICommandHandlerWithResultAsync<AddressCreateCommand>

    {
        private readonly IPersonRepository personRepository;
        private readonly IValidator<PersonCreateCommand> createValidationHandler;
        private readonly IValidator<PersonUpdateCommand> updateValidationHandler;
        private readonly IValidator<EmailAddressDeleteCommand> deleteMailValidationHandler;
        private readonly IValidator<EmailAddressCreateCommand> createMailValidationHandler;
        private readonly IValidator<EmailAddressUpdateCommand> updateMailValidationHandler;
        private readonly IValidator<AddressDeleteCommand> deleteAddressValidationHandler;
        private readonly IValidator<AddressCreateCommand> createAddressValidationHandler;
        private readonly IValidator<AddressUpdateCommand> updateAddressValidationHandler;

        public PersonCommandHandler(
            IPersonRepository personRepository,
            IValidator<PersonCreateCommand> createValidationHandler,
            IValidator<PersonUpdateCommand> updateValidationHandler,
            IValidator<EmailAddressDeleteCommand> deleteMailValidationHandler,
            IValidator<EmailAddressCreateCommand> createMailValidationHandler,
            IValidator<EmailAddressUpdateCommand> updateMailValidationHandler,
            IValidator<AddressDeleteCommand> deleteAddressValidationHandler,
            IValidator<AddressCreateCommand> createAddressValidationHandler,
            IValidator<AddressUpdateCommand> updateAddressValidationHandler)
        {
            this.personRepository = personRepository;
            this.createValidationHandler = createValidationHandler;
            this.updateValidationHandler = updateValidationHandler;
            this.deleteMailValidationHandler = deleteMailValidationHandler;
            this.createMailValidationHandler = createMailValidationHandler;
            this.updateMailValidationHandler = updateMailValidationHandler;
            this.deleteAddressValidationHandler = deleteAddressValidationHandler;
            this.createAddressValidationHandler = createAddressValidationHandler;
            this.updateAddressValidationHandler = updateAddressValidationHandler;

        }

        public async Task<ICommandHandlerAnswer> HandleAsync(PersonCreateCommand command)
        {            
            var answer = new CommandHandlerAnswer
            {
                ValidationResult = this.createValidationHandler.Validate(command),
                AggregateRoot = await personRepository.Insert(new Person(command))
            };

            await personRepository.UnitOfWork.SaveChangesAsync();

            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(PersonUpdateCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.Id);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.updateValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));                
                }               
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(EmailAddressDeleteCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.deleteMailValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(EmailAddressUpdateCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.updateMailValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(EmailAddressCreateCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.createMailValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(AddressDeleteCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.deleteAddressValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(AddressUpdateCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.updateAddressValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAnswer> HandleAsync(AddressCreateCommand command)
        {
            var answer = new CommandHandlerAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.createAddressValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }
    }
}