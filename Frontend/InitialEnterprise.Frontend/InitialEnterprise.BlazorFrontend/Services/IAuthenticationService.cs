using InitialEnterprise.Shared.Dtos;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public interface IAuthenticationService
    {
        Task<UserSignInResultDto> Login(UserLoginDto userLogin);
        Task Logout();
    }
}
