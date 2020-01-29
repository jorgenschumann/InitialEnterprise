using FluentValidation;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.ValidationHandler
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 8)
        {
            var ruleBuilderOptions = ruleBuilder
                .NotEmpty().WithMessage("Password Empty")
                .MinimumLength(minimumLength).WithMessage("Password Length required")
                .Matches("[A-Z]").WithMessage("Password Uppercase Letter required")
                .Matches("[a-z]").WithMessage("Password Lowercase Letter required")
                .Matches("[0-9]").WithMessage("Password Digit required")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password Special Character required");
            return ruleBuilderOptions;
        }
    }
}

