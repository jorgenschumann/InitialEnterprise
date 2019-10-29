using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class CreateCreditCardCommandValidatorHandler : CommandValidator<CreditCardCreateCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreditCardCreateCommand> context)
        {
            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Card Id missing");

            RuleFor(c => c.PersonId)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Person Id missing");

            RuleFor(c => c.CreditCardHolderName)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("CreditCardHolderName missing");

            RuleFor(c => c.CreditCardType)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .WithMessage("CreditCardType missing");

            RuleFor(c => c.CardNumber)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error).WithMessage("CardNumber missing")
               .MinimumLength(12).WithMessage("CardNumber min lenght")
               .MaximumLength(16).WithMessage("CardNumber max lenght");

            RuleFor(c => c.ExpireMonth)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)             
               .WithMessage("ExpireMonth missing");
           
            RuleFor(c => c.ExpireYear)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("CreditCardType missing");

            return base.Validate(context);
        }
    }
}