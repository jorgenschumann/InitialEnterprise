using InitialEnterprise.BlazorFrontend.Models;
using InitialEnterprise.Shared.Dtos.User;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public interface IAuthenticationService
    {
        Task<UserSignInResultDto> Login(UserLogin userLogin);
    }
}
