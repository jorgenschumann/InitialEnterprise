using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.ValidationHandler
{
    public class CreateCurrencyCommandValidationHandler : AbstractValidator<CreateCurrencyCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreateCurrencyCommand> context)
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

        //public ValidationResult Validate(ValidationContext<CreateCurrencyCommand> context)
        //{
        //    return this.Validate(context);
        //}
    }


   
}
