using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.ValidationHandler
{

    public class RegisterCommandValidationHandler : CommandValidator<UserRegisterCommand>
    {
        public override ValidationResult Validate(ValidationContext<UserRegisterCommand> context)
        {         
            ValdidatePassword();
            return base.Validate(context);
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

