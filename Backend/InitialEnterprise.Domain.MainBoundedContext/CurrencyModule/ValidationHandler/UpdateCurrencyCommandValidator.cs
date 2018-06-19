using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand> 
    {
        public override ValidationResult Validate(ValidationContext<UpdateCurrencyCommand> context)
        {
            return base.Validate(context);  
        }

        //protected void ValidateName()
        //{
        //    RuleFor(c => c.Name)
        //        .NotEmpty().WithMessage("Name")
        //        .Length(4, 100).WithMessage("Name must have....");
        //}

        //protected void ValidateIsoCode()
        //{
        //    RuleFor(c => c.Name)
        //        .NotEmpty().WithMessage("IsoCode")
        //        .Length(3, 3).WithMessage("IsoCode must have....");
        //}
    }
}