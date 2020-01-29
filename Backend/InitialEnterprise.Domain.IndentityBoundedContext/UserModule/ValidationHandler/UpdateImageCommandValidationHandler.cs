using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.ValidationHandler
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