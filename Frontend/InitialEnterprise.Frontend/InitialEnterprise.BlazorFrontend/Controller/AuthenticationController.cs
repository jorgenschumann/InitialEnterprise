using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Controller
{
    public class AuthenticationController
    {
        private readonly IBusyIndicatorService busyIndicatorService;
        private readonly IAuthenticationService authenticationService;
        private readonly NavigationManager navigationManager;

        public AuthenticationController(
            IBusyIndicatorService busyIndicatorService,
             IAuthenticationService authenticationService,
             NavigationManager navigationManager
            )
        {
            this.busyIndicatorService = busyIndicatorService;
            this.authenticationService = authenticationService;
            this.navigationManager = navigationManager;
        }              

        public async Task<UserSignInResultDto> Login(UserLoginDto userLogin)
        {
            using (busyIndicatorService.Show())
            {            
                var userSignInResult = await authenticationService.Login(userLogin);
                if (userSignInResult.Success)
                {
                    navigationManager.NavigateTo("/");
                }
                return userSignInResult;
            }
        }

        public async Task Logout()
        {
            using (busyIndicatorService.Show())
            {
                await authenticationService.Logout();            
                navigationManager.NavigateTo("/");   
            }
        }
    }
}
