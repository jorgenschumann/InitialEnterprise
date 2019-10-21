using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
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
          ICommandHandlerWithResultAsync<AddressCreateCommand>,
          ICommandHandlerWithResultAsync<CreditCardCreateCommand>,
          ICommandHandlerWithResultAsync<CreditCardUpdateCommand>,
          ICommandHandlerWithResultAsync<CreditCardDeactivateCommand>,
          ICommandHandlerWithResultAsync<CreditCardDeleteCommand>

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
        private readonly IValidator<CreditCardDeleteCommand> deleteCreditCardValidationHandler;
        private readonly IValidator<CreditCardDeactivateCommand> deactivateCreditCardValidationHandler;
        private readonly IValidator<CreditCardUpdateCommand> udateCreditCardValidationHandler;
        private readonly IValidator<CreditCardCreateCommand> createCreditCardValidationHandler;

        public PersonCommandHandler(
            IPersonRepository personRepository,
            IValidator<PersonCreateCommand> createValidationHandler,
            IValidator<PersonUpdateCommand> updateValidationHandler,
            IValidator<EmailAddressDeleteCommand> deleteMailValidationHandler,
            IValidator<EmailAddressCreateCommand> createMailValidationHandler,
            IValidator<EmailAddressUpdateCommand> updateMailValidationHandler,
            IValidator<AddressDeleteCommand> deleteAddressValidationHandler,
            IValidator<AddressCreateCommand> createAddressValidationHandler,
            IValidator<AddressUpdateCommand> updateAddressValidationHandler,
            IValidator<CreditCardDeleteCommand> deleteCreditCardValidationHandler,
            IValidator<CreditCardDeactivateCommand> deactivateCreditCardValidationHandler,
            IValidator<CreditCardUpdateCommand> udateCreditCardValidationHandler,
            IValidator<CreditCardCreateCommand> createCreditCardValidationHandler)
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
            this.deleteCreditCardValidationHandler = deleteCreditCardValidationHandler;
            this.deactivateCreditCardValidationHandler = deactivateCreditCardValidationHandler;
            this.udateCreditCardValidationHandler = udateCreditCardValidationHandler;
            this.createCreditCardValidationHandler = createCreditCardValidationHandler;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(PersonCreateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer
            {
                ValidationResult = this.createValidationHandler.Validate(command),
                AggregateRoot = await personRepository.Insert(new Person(command))
            };

            await personRepository.UnitOfWork.SaveChangesAsync();

            return answer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(PersonUpdateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(EmailAddressDeleteCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(EmailAddressUpdateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(EmailAddressCreateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(AddressDeleteCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(AddressUpdateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(AddressCreateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
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

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CreditCardCreateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.createCreditCardValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CreditCardUpdateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.udateCreditCardValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CreditCardDeactivateCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.deactivateCreditCardValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }

        public async Task<ICommandHandlerAggregateAnswer> HandleAsync(CreditCardDeleteCommand command)
        {
            var answer = new CommandHandlerAggregateAnswer();
            var person = await personRepository.Query(command.PersonId);
            if (person.IsNotNull())
            {
                answer.ValidationResult = this.deleteCreditCardValidationHandler.Validate(command);

                if (command.IsValid)
                {
                    answer.AggregateRoot = await personRepository.Update(person.Take(command));
                }
            }
            return answer;
        }
    }
}