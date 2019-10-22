using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class DeleteAddressCommandValidatorHandler : CommandValidator<AddressDeleteCommand>
    {
        public override ValidationResult Validate(ValidationContext<AddressDeleteCommand> context)
        {
            RuleFor(c => c.PersonId)
           .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
           .WithMessage("Person Id missing");

            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Address Id missing");          

            return base.Validate(context);
        }
    }
}