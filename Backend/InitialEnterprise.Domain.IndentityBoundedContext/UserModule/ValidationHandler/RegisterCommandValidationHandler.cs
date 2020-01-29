using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.ValidationHandler
{
    public class RegisterCommandValidationHandler : CommandValidator<UserRegisterCommand>
    {
        public override ValidationResult Validate(ValidationContext<UserRegisterCommand> context)
        {
            ValidateFistName();
            ValidateLastName();
            ValidateDateOfBirth();
            ValidateEmail();
            ValdidatePassword();
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
                .NotEmpty().WithMessage(nameof(UserRegisterCommand.Email))
                .EmailAddress().WithMessage("A valid email is required");
        }

        protected void ValdidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage(nameof(UserRegisterCommand.Password))
                .Password();
        }
    }
}