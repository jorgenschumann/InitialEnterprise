using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class DeleteCreditCardCommandValidatorHandler : CommandValidator<CreditCardDeleteCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreditCardDeleteCommand> context)
        {
            RuleFor(c => c.PersonId)
           .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
           .WithMessage("Person Id missing");

            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Address Id missing");          

            return base.Validate(context);
        }
    }
}