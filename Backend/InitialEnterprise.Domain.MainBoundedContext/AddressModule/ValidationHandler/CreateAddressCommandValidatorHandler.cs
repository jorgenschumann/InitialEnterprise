using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Validation;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class CreateAddressCommandValidatorHandler : CommandValidator<AddressCreateCommand>
    {
        public override ValidationResult Validate(ValidationContext<AddressCreateCommand> context)
        {
            RuleFor(c => c.PersonId)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Person Id missing");

            RuleFor(c => c.Id)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Address Id missing");

            RuleFor(c => c.City)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Address City missing");

            RuleFor(c => c.Country)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Address Country missing");

            RuleFor(c => c.City)
              .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
              .WithMessage("Address City missing");

            RuleFor(c => c.Province)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Address Province missing");

            RuleFor(c => c.Street)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Address Street missing");

            RuleFor(c => c.Number)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Address Number missing");

            RuleFor(c => c.Zip)
               .NotEmpty().WithErrorCode(ValidationErrorCode.Error)
               .WithMessage("Address Zip missing");

            return base.Validate(context);
        }
    }
}