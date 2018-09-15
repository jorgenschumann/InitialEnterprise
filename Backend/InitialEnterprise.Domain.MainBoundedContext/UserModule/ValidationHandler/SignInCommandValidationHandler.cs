using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.ValidationHandler
{
    public class SignInCommandValidationHandler : CommandValidator<SignInCommand>
    {
        public override ValidationResult Validate(ValidationContext<SignInCommand> context)
        {
            //ValidateEmail();
            ValdidatePassword();
            return base.Validate(context);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(nameof(SignInCommand.Email))
                .EmailAddress().WithMessage("A valid email is required");
        }

        protected void ValdidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage(nameof(SignInCommand.Password))
                .Password();
        }
    }
}

