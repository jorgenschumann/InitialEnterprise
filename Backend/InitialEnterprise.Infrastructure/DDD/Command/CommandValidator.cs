using FluentValidation;
using FluentValidation.Results;

namespace InitialEnterprise.Infrastructure.DDD.Command
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : DomainCommand
    {
        public override ValidationResult Validate(ValidationContext<TCommand> context)
        {
            var validationResult = base.Validate(context);
            {
                context.InstanceToValidate.IsValid = validationResult.IsValid;
            }
            return validationResult;
        }
    }
}