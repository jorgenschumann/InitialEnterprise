using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
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
              .WithMessage("Card Id missing");          

            return base.Validate(context);
        }
    }

    public class DectivateCreditCardCommandValidatorHandler : CommandValidator<CreditCardDeactivateCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreditCardDeactivateCommand> context)
        {
            RuleFor(c => c.PersonId)
           .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
           .WithMessage("Person Id missing");

            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Card Id missing");

            return base.Validate(context);
        }
    }
}