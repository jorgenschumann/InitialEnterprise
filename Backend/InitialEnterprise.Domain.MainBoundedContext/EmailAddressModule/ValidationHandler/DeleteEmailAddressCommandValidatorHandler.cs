using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class DeleteEmailAddressCommandValidatorHandler : CommandValidator<EmailAddressDeleteCommand>
    {
        public override ValidationResult Validate(ValidationContext<EmailAddressDeleteCommand> context)
        {
            RuleFor(c => c.PersonId)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Person Id missing");

            RuleFor(c => c.MailAddressId)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .WithMessage("MailAddress Id missing");

            return base.Validate(context);
        }
    }
}