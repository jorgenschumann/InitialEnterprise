using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.ValidationHandler
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

