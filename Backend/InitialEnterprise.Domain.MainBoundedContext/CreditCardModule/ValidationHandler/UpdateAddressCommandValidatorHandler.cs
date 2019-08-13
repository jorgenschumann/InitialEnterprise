using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdateCreditCardCommandValidatorHandler : CommandValidator<CreditCardUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreditCardUpdateCommand> context)
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .WithMessage("Address Id missing");

            RuleFor(c => c.PersonId)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Person Id missing");

            RuleFor(c => c.CreditCardType)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .WithMessage("CreditCardType Id missing");

            RuleFor(c => c.CardNumber)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("CardNumber Id missing");

            RuleFor(c => c.ExpireMonth)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("ExpireMonth Id missing");

            RuleFor(c => c.ExpireYear)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("CreditCardType Id missing");


            return base.Validate(context);
        }
    }
}