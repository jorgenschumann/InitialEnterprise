using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.ValidationHandler
{
    public class UpdateCommandValidationHandler : CommandValidator<UserUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<UserUpdateCommand> context)
        {
            ValdidatePassword();
            return base.Validate(context);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(nameof(UserUpdateCommand.Email))
                .EmailAddress().WithMessage("A valid email is required");
        }

        protected void ValdidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage(nameof(UserUpdateCommand.Password))
                .Password();
        }
    }
}

