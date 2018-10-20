using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.ValidationHandler
{
    public class CreatePersonCommandValidationHandler : CommandValidator<CreatePersonCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreatePersonCommand> context)
        {
            ValidateFirstName();
            ValidateLastnameCode();
            return base.Validate(context);
        }

        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("FirstName")
                .Length(4, 100).WithMessage("FirstName must have....");
        }

        protected void ValidateLastnameCode()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("LastName")
                   .Length(4, 100).WithMessage("LastName must have....");
        }
    }
   
}