using System.Threading.Tasks;
using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using Microsoft.AspNetCore.Identity;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.CommandHandler
{
    public class UserAccountCommandHandler :
         ICommandHandlerWithResultAsync<SignInCommand, UserSignInResult>,
         ICommandHandlerWithResultAsync<UserRegisterCommand, IdentityResult>,
         ICommandHandlerWithResultAsync<UserUpdateCommand, IdentityResult>

    {
        readonly IValidator<SignInCommand> loginValidationHandler;
        readonly IValidator<UserRegisterCommand> registerValidationHandler;
        readonly IValidator<UserUpdateCommand> updateValidationHandler;
        readonly SignInManager<ApplicationUser> signInManager;
        readonly UserManager<ApplicationUser> userManager;
        readonly IJwtSecurityTokenBuilder tokenBuilder;

        public UserAccountCommandHandler(
            IValidator<SignInCommand> loginValidationHandler,
            IValidator<UserRegisterCommand> registerValidationHandler,
            IValidator<UserUpdateCommand> updateValidationHandler,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtSecurityTokenBuilder tokenBuilder)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidationHandler = loginValidationHandler;
            this.updateValidationHandler = updateValidationHandler;
            this.registerValidationHandler = registerValidationHandler;
            this.tokenBuilder = tokenBuilder;
        }

        public async Task<UserSignInResult> HandleAsync(SignInCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = loginValidationHandler.Validate(command)
            };

            var userSignInResult = new UserSignInResult { SignInResult = SignInResult.Failed };

            if (command.IsValid)
            {
                var user = await userManager.FindByEmailAsync(command.Email);
                var claims = await userManager.GetClaimsAsync(user);
                var result = await signInManager.PasswordSignInAsync(user, command.Password, command.Remember, true);

                if (result.Succeeded)
                {                      
                    return new UserSignInResult
                    {
                        User = user,
                        Token = tokenBuilder.CreateToken(user),
                        SignInResult = result                    
                    };
                }              
            }
            return userSignInResult;
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
