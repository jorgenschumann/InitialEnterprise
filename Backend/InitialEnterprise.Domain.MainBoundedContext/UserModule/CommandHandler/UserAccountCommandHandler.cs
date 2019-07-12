using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.CommandHandler
{
    public class UserAccountCommandHandler :
         ICommandHandlerWithResultAsync<SignInCommand, UserSignInResult>,
         ICommandHandlerWithResultAsync<UserRegisterCommand, IdentityResult>,
         ICommandHandlerWithResultAsync<UserUpdateCommand, IdentityResult>,
         ICommandHandlerWithResultAsync<UserUpdateImageCommand, ApplicationUser>,
         ICommandHandlerWithResultAsync<UserRemoveImageCommand, ApplicationUser>

    {
        private readonly IValidator<SignInCommand> loginValidationHandler;
        private readonly IValidator<UserRegisterCommand> registerValidationHandler;
        private readonly IValidator<UserUpdateCommand> updateValidationHandler;
        private readonly IValidator<UserUpdateImageCommand> updateImageValidationHandler;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtSecurityTokenBuilder tokenBuilder;

        public UserAccountCommandHandler(
            IValidator<SignInCommand> loginValidationHandler,
            IValidator<UserRegisterCommand> registerValidationHandler,
            IValidator<UserUpdateCommand> updateValidationHandler,
            IValidator<UserUpdateImageCommand> updateImageValidationHandler,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtSecurityTokenBuilder tokenBuilder)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidationHandler = loginValidationHandler;
            this.updateValidationHandler = updateValidationHandler;
            this.updateImageValidationHandler = updateImageValidationHandler;
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
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, command.Password, command.Remember, true);

                    if (result.Succeeded)
                    {
                        await MergeClaims(user);

                        return new UserSignInResult
                        {
                            User = user,
                            Token = tokenBuilder.CreateToken(user),
                            SignInResult = result
                        };
                    }
                }
            }
            return userSignInResult;
        }

        private async Task MergeClaims(ApplicationUser user)
        {
            var claims = await userManager.GetClaimsAsync(user);
            user.Claims = new List<ApplicationUserClaim>();
            foreach (var claim in claims)
            {
                user.Claims.Add(new ApplicationUserClaim { ClaimType = claim.Type, ClaimValue = claim.Value });
            }
        }

        public async Task<IdentityResult> HandleAsync(UserRegisterCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = registerValidationHandler.Validate(command)
            };

            var identityResult = new IdentityResult();
            if (commandHandlerAnswer.ValidationResult.IsValid)
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
            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                var user = await userManager.FindByEmailAsync(command.Email);
                user.Update(command);
                identityResult = await userManager.UpdateAsync(user);
            }
            return identityResult;
        }

        public async Task<ApplicationUser> HandleAsync(UserUpdateImageCommand command)
        {
            var commandHandlerAnswer = new CommandHandlerAnswer
            {
                ValidationResult = updateImageValidationHandler.Validate(command)
            };
            var user = await userManager.FindByIdAsync(command.Id.ToString());
            if (commandHandlerAnswer.ValidationResult.IsValid)
            {
                user.Update(command);
                await userManager.UpdateAsync(user);
            }
            return user;
        }

        public async Task<ApplicationUser> HandleAsync(UserRemoveImageCommand command)
        {
            var user = await userManager.FindByIdAsync(command.Id.ToString());
            {
                user.Update(command);

                await userManager.UpdateAsync(user);
            }     
            return user;
        }
    }
}