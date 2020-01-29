using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Frontend.Infrastructure
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService _localStorage;
        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authToken = await _localStorage.GetItemAsync<string>("authToken");
            var authUser = await _localStorage.GetItemAsync<UserDto>("authUser");

            if (string.IsNullOrWhiteSpace(authToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authToken);
                    
            return new AuthenticationState(ParseFromUserDto(authUser));
        }

        public async Task<UserDto> GetAuthenticationUserDtoAsync()
        {            
            return await _localStorage.GetItemAsync<UserDto>("authUser");
        }        

        public async Task<(bool IsAuthenticated, UserDto User)> GetStateAsync()
        {
            var user = await _localStorage.GetItemAsync<UserDto>("authUser");
            return (IsAuthenticated: user != null, User: user);
        }

        public void MarkUserAsAuthenticated(UserDto userDto)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userDto.UserName)
            }, "authUser"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));            

            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private ClaimsPrincipal ParseFromUserDto(UserDto userDto)
        {
           return new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userDto.UserName)
            }, "authUser"));
        }
        
        public async Task<IEnumerable<Claim>> GetAuthenticationUserClaims()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var claims = new List<Claim>();
            var payload = token.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
