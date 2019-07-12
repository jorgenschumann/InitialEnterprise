using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdateEmailAddressCommandValidatorHandler : CommandValidator<EmailAddressUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<EmailAddressUpdateCommand> context)
        {
            RuleFor(c => c.PersonId)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Person Id missing");

            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("MailAddress Id missing");

            RuleFor(c => c.MailAddress)
                 .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                 .WithMessage("MailAddress missing");

            RuleFor(c => c.MailAddressType)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("MailAddressType missing");

            return base.Validate(context);
        }
    }
}