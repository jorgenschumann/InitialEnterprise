using Blazored.Toast.Services;
using InitialEnterprise.Blazor.Frontend.Settings;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using InitialEnterprise.Blazor.Frontend.Infrastructure;
using InitialEnterprise.Blazor.Frontend.Services;
using System.Net.Http;
using Blazored.LocalStorage;
using InitialEnterprise.Blazor.Frontend.UiServices;
using Blazored.Modal;
using InitialEnterprise.Blazor.Frontend.Pages.Currency;
using Microsoft.AspNetCore.Components.Authorization;
using InitialEnterprise.Blazor.Frontend.Pages.User;
using InitialEnterprise.Blazor.Frontend.Pages.Person;
using InitialEnterprise.Blazor.Frontend.Pages.Person.CreditCard;
using InitialEnterprise.Blazor.Frontend.Pages.Person.MailAddress;
using InitialEnterprise.Blazor.Frontend.Pages.Person.Address;

namespace InitialEnterprise.Blazor.Frontend
{
    public class Startup
    {
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {  
            services.AddSingleton<ApiSettings>();

            services.AddScoped<ToastService>();
            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage();
            //services.AddAuthenticationCore();
            services.AddAuthorizationCore();

            services.AddScoped<HttpClient>();
            services.AddScoped<IRequestService, RequestService>();

            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(provider =>
            provider.GetRequiredService<ApiAuthenticationStateProvider>());

            services.AddScoped<BusyIndicatorService>();
            services.AddScoped<IBusyIndicatorService>(p => p.GetRequiredService<BusyIndicatorService>());

            services.AddScoped<MessageBoxService>();
            services.AddScoped<IMessageBoxService>(p => p.GetRequiredService<MessageBoxService>());

            services.AddScoped<AuthenticationController>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<INavigationService, NavigationService>();

            services.AddScoped<CurrencyController>();
            services.AddScoped<ICurrencyService, CurrencyService>();

            services.AddScoped<UserController>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INavigationService, NavigationService>();

            services.AddScoped<PersonController>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<CreditCardController>();
            services.AddScoped<ICreditCardService, CreditCardService>();

            services.AddScoped<EmailAddressController>();
            services.AddScoped<IEmailAddressService, EmailAddressService>();

            services.AddScoped<AddressController>();
            services.AddScoped<IPersonAddressService, PersonAddressService>();

        }

    }
}
