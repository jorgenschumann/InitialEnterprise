using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdatePersonCommandValidationHandler : CommandValidator<UpdatePersonCommand>
    {
        public override ValidationResult Validate(ValidationContext<UpdatePersonCommand> context)
        {
            ValidateFirstName();
            ValidateLastnameCode();
            return base.Validate(context);
        }

        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("FirstName")
                .Length(1, 100).WithMessage("FirstName must have....");
        }

        protected void ValidateLastnameCode()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("LastName")
                   .Length(1, 100).WithMessage("LastName must have....");
        }
    }
}