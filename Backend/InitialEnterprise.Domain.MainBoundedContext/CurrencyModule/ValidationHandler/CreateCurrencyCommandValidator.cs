using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{

    public class CreateCurrencyCommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : CreateCurrencyCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name")
                .Length(4, 100).WithMessage("Name must have....");
        }

        protected void ValidateIsoCode()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("IsoCode")
                .Length(3, 3).WithMessage("IsoCode must have....");
        }
    }
}
