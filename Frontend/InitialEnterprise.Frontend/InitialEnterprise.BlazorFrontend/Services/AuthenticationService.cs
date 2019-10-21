using InitialEnterprise.BlazorFrontend.Infrastructure;
using InitialEnterprise.BlazorFrontend.Models;
using InitialEnterprise.Shared.Dtos.User;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using System.Net.Http;
using InitialEnterprise.BlazorFrontend.Settings;

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

        public async Task<UserSignInResultDto> Login(UserLogin userLogin)
        {
            var result =  await requestService.PostAsync<UserLogin, UserSignInResultDto>($"{apiSettings.Url}/useraccount/login", userLogin);      
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

    //public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    //{
    //    private readonly HttpClient _httpClient;
    //    private readonly ILocalStorageService _localStorage;

    //    public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    //    {
    //        _httpClient = httpClient;
    //        _localStorage = localStorage;
    //    }
    //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        var savedToken = await _localStorage.GetItemAsync<string>("authToken");

    //        if (string.IsNullOrWhiteSpace(savedToken))
    //        {
    //            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    //        }

    //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);

    //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
    //    }

    //    public void MarkUserAsAuthenticated(string email)
    //    {
    //        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
    //        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
    //        NotifyAuthenticationStateChanged(authState);
    //    }

    //    public void MarkUserAsLoggedOut()
    //    {
    //        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
    //        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
    //        NotifyAuthenticationStateChanged(authState);
    //    }

    //    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    //    {
    //        var claims = new List<Claim>();
    //        var payload = jwt.Split('.')[1];
    //        var jsonBytes = ParseBase64WithoutPadding(payload);
    //        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

    //        keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

    //        if (roles != null)
    //        {
    //            if (roles.ToString().Trim().StartsWith("["))
    //            {
    //                var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

    //                foreach (var parsedRole in parsedRoles)
    //                {
    //                    claims.Add(new Claim(ClaimTypes.Role, parsedRole));
    //                }
    //            }
    //            else
    //            {
    //                claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
    //            }

    //            keyValuePairs.Remove(ClaimTypes.Role);
    //        }

    //        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

    //        return claims;
    //    }

    //    private byte[] ParseBase64WithoutPadding(string base64)
    //    {
    //        switch (base64.Length % 4)
    //        {
    //            case 2: base64 += "=="; break;
    //            case 3: base64 += "="; break;
    //        }
    //        return Convert.FromBase64String(base64);
    //    }
    //}
}
