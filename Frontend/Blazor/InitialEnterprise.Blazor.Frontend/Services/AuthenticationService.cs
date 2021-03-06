﻿using InitialEnterprise.Frontend.Infrastructure;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using System.Net.Http;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;

namespace InitialEnterprise.Frontend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestService requestService;
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;
        private readonly ApiSettings apiSettings;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(
            IRequestService requestService, 
            ILocalStorageService localStorage, 
            HttpClient httpClient, 
            ApiSettings apiSettings,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this.requestService = requestService;
            this.localStorage = localStorage;
            this.httpClient = httpClient;        
            this.apiSettings = apiSettings;
            this.authenticationStateProvider = authenticationStateProvider;
        }        

        public async Task<UserSignInResultDto> Login(UserLoginDto userLogin)
        {
            var result =  await requestService.PostAsync<UserLoginDto, UserSignInResultDto>(
                $"{apiSettings.IndentityUrl}/authentication/login", userLogin);      

            if (result.Success)
            {
                await localStorage.SetItemAsync("authToken", result.Token);
                await localStorage.SetItemAsync("authUser", result.User);
                ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(result.User);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);               
            }
            return result;
        }       

        public async Task Logout()
        {          
            await localStorage.RemoveItemAsync("authToken");
            await localStorage.RemoveItemAsync("authUser");
            httpClient.DefaultRequestHeaders.Authorization = null;
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
        }   
    } 
}
