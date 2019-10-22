using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdatePersonCommandValidationHandler : CommandValidator<PersonUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<PersonUpdateCommand> context)
        {
            ValidateFirstName();
            ValidateLastnameCode();
            return base.Validate(context);
        }

        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .Length(2, 100).WithMessage("Firstname length must beetwen 2 and 100 charakters");
        }

        protected void ValidateLastnameCode()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                   .Length(2, 100).WithMessage("LastName length must beetwen 2 and 100 charakters");
        }
    }
}