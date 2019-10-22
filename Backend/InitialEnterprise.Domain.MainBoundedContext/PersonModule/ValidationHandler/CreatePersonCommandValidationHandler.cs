using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.ValidationHandler
{
    public class CreatePersonCommandValidationHandler : CommandValidator<PersonCreateCommand>
    {
        public override ValidationResult Validate(ValidationContext<PersonCreateCommand> context)
        {
            ValidateFirstName();
            ValidateLastnameCode();
            return base.Validate(context);
        }

        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                .Length(1, 100).WithMessage("FirstName must have....");
        }

        protected void ValidateLastnameCode()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
                   .Length(1, 100).WithMessage("LastName must have....");
        }
    }
   
}