using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.ValidationHandler
{
    public class UpdateImageCommandValidationHandler : CommandValidator<UserUpdateImageCommand>
    {
        public override ValidationResult Validate(ValidationContext<UserUpdateImageCommand> context)
        {
            ValidateImage();
          
            return base.Validate(context);
        }

        protected void ValidateImage()
        {
            RuleFor(c => c.Image)
                .NotNull()
                .WithMessage(nameof(UserUpdateImageCommand.Image))
                .WithMessage("A valid image is required");
        }
    }
}