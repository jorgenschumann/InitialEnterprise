using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public interface IAuthenticationApplication
    {
        Task<UserSignInResultDto> LogIn(UserLoginDto model);

        Task<UserSignInResult> SignIn(UserLoginDto model);

        Task<IdentityResult> Register(UserRegisterDto model);
    }
}