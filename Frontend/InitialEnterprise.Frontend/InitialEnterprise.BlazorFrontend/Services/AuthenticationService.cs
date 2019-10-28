using InitialEnterprise.BlazorFrontend.Infrastructure;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using System.Net.Http;
using InitialEnterprise.BlazorFrontend.Settings;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestService requestService;
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;
        private readonly ApiSettings apiSettings;

        public AuthenticationService(
            IRequestService requestService, 
            ILocalStorageService localStorage, 
            HttpClient httpClient, 
            ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.localStorage = localStorage;
            this.httpClient = httpClient;        
            this.apiSettings = apiSettings;
        }        

        public async Task<UserSignInResultDto> Login(UserLoginDto userLogin)
        {
            var result =  await requestService.PostAsync<UserLoginDto, UserSignInResultDto>(
                $"{apiSettings.Url}/useraccount/login", userLogin);      

            if (result.Success)
            {
                await localStorage.SetItemAsync("authToken", result.Token);               
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);               
            }
            return result;
        }       

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("authToken");   
            httpClient.DefaultRequestHeaders.Authorization = null;
        }   
    } 
}
