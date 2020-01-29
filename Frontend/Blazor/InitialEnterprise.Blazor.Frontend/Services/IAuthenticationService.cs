using InitialEnterprise.Shared.Dtos;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface IAuthenticationService
    {
        Task<UserSignInResultDto> Login(UserLoginDto userLogin);
        Task Logout();
    }
}
