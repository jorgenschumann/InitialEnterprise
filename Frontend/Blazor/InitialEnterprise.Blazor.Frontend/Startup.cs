using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InitialEnterprise.Frontend.Settings;
using Blazored.Toast.Services;
using Blazored.Modal;
using Blazored.LocalStorage;
using System.Net.Http;
using InitialEnterprise.Frontend.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using InitialEnterprise.Frontend.UiServices;
using InitialEnterprise.Frontend.Pages.User;
using InitialEnterprise.Frontend.Services;
using InitialEnterprise.Frontend.Pages.Currency;
using InitialEnterprise.Frontend.Pages.Person;
using InitialEnterprise.Frontend.Pages.Person.CreditCard;
using InitialEnterprise.Frontend.Pages.Person.MailAddress;
using InitialEnterprise.Frontend.Pages.Person.Address;
using InitialEnterprise.Frontend.Pages.Country;
using Blazor.Fluxor;

namespace InitialEnterprise.Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddFluxor(options => options.UseDependencyInjection(typeof(Startup).Assembly));

            services.AddSingleton<ApiSettings>();

            services.AddScoped<ToastService>();
            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage();
            services.AddAuthenticationCore();
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

            services.AddScoped<CountryController>();
            services.AddScoped<ICountryService, CountryService>();

         
            services.AddScoped<ICustomerService, CustomerService>();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
