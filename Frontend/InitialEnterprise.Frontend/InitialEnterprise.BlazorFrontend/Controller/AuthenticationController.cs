using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Controller
{
    public class AuthenticationController
    {
        private readonly IBusyIndicatorService busyIndicatorService;
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(
            IBusyIndicatorService busyIndicatorService,
             IAuthenticationService authenticationService
            )
        {
            this.busyIndicatorService = busyIndicatorService;
            this.authenticationService = authenticationService;
        }              

        public async Task<UserSignInResultDto> Login(UserLoginDto userLogin)
        {
            using (busyIndicatorService.Show())
            {            
                return await this.authenticationService.Login(userLogin);
            }
        }
    }
}
