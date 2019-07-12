using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.ValidationHandler
{

    public class UpdateCommandValidationHandler : CommandValidator<UserUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<UserUpdateCommand> context)
        {
            ValidateFistName();
            ValidateLastName();
            ValidateDateOfBirth();
            ValidateEmail();
            return base.Validate(context);
        }

        protected void ValidateFistName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage(nameof(UserRegisterCommand.FirstName))
                .WithMessage("A valid firstname is required");
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
              .NotEmpty().WithMessage(nameof(UserRegisterCommand.LastName))
              .WithMessage("A valid lastname is required");
        }

        protected void ValidateDateOfBirth()
        {
            RuleFor(c => c.DateOfBirth)
                .NotNull().WithMessage(nameof(UserRegisterCommand.DateOfBirth))
                .WithMessage("A valid date of birth is required");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}