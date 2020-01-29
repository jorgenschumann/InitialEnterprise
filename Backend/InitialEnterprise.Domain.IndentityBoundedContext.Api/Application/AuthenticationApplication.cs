using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using AgileObjects.AgileMapper;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public class AuthenticationApplication : IAuthenticationApplication
    {
        private readonly IDispatcher dispatcher;

        public AuthenticationApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<UserSignInResultDto> LogIn(UserLoginDto model)
        {
            var command = Mapper.Map(model).ToANew<SignInCommand>();
            var result = await dispatcher.SendR<SignInCommand, UserSignInResult>(command);

            return Mapper.Map(result).ToANew<UserSignInResultDto>(
                cfg => cfg.Map(x => x.Source.SignInResult.Succeeded).To(x => x.Success));
        }

        public async Task<UserSignInResult> SignIn(UserLoginDto model)
        {
            var command = Mapper.Map(model).ToANew<SignInCommand>();
            return await dispatcher.SendR<SignInCommand, UserSignInResult>(command);
        }

        public async Task<IdentityResult> Register(UserRegisterDto model)
        {
            var command = Mapper.Map(model).ToANew<UserRegisterCommand>();
            return await dispatcher.SendR<UserRegisterCommand, IdentityResult>(command);
        }
    }
}