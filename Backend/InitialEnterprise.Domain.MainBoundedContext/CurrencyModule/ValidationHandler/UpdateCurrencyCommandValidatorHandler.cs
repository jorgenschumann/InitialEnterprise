using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdateCurrencyCommandValidatorHandler : CommandValidator<CurrencyUpdateCommand>
    {
        public override ValidationResult Validate(ValidationContext<CurrencyUpdateCommand> context)
        {
            ValidateName();
            ValidateIsoCode();
            return base.Validate(context);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)               
                .Length(4, 100)
                .WithMessage("Name length must beetwen 4 and 100 charakters");
        }

        protected void ValidateIsoCode()
        {
            RuleFor(c => c.IsoCode)                       
                .Length(3, 3)
                .WithMessage("IsoCode must have 3 charakters");
        }
    }
}