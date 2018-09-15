using System.Threading.Tasks;
using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using Microsoft.AspNetCore.Identity;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.CommandHandler
{
    public class UserAccountCommandHandler :
         ICommandHandlerWithResultAsync<SignInCommand, SignInResult>,
         ICommandHandlerWithResultAsync<UserRegisterCommand, IdentityResult>,
         ICommandHandlerWithResultAsync<UserUpdateCommand, IdentityResult>

    {
        readonly IValidator<SignInCommand> loginValidationHandler;
        readonly IValidator<UserRegisterCommand> registerValidationHandler;
        readonly IValidator<UserUpdateCommand> updateValidationHandler;
        readonly SignInManager<ApplicationUser> signInManager;
        readonly UserManager<ApplicationUser> userManager;

        public UserAccountCommandHandler(
            IValidator<SignInCommand> loginValidationHandler,
            IValidator<UserRegisterCommand> registerValidationHandler,
            IValidator<UserUpdateCommand> updateValidationHandler,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidationHandler = loginValidationHandler;
            this.updateValidationHandler = updateValidationHandler;
            this.registerValidationHandler = registerValidationHandler;
        }

        public async Task<SignInResult> HandleAsync(SignInCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = loginValidationHandler.Validate(command)
            };
            if (command.IsValid)
            {
                var user = await userManager.FindByEmailAsync(command.Email);
                return await signInManager.PasswordSignInAsync(user, command.Password, command.Remember, true);
            }
            return SignInResult.Failed;
        }

        public async Task<IdentityResult> HandleAsync(UserRegisterCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = registerValidationHandler.Validate(command)
            };

            var identityResult = new IdentityResult();
            if (command.IsValid)
            {
                var user = new ApplicationUser(command);
                identityResult = await userManager.CreateAsync(user);                
            }
            return identityResult;
        }

        public async Task<IdentityResult> HandleAsync(UserUpdateCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = updateValidationHandler.Validate(command)
            };
            var identityResult = new IdentityResult();
            if (command.IsValid)
            {
                var user = await userManager.FindByEmailAsync(command.Email);
                user.Update(command);
                identityResult = await userManager.UpdateAsync(user);
            }
            return identityResult;
        }        
    }
}
