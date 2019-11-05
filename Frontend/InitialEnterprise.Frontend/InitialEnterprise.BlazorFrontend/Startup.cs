using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InitialEnterprise.BlazorFrontend.Infrastructure;
using InitialEnterprise.BlazorFrontend.Services;
using System.Net.Http;
using Blazored.LocalStorage;
using InitialEnterprise.BlazorFrontend.Settings;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.BlazorFrontend.Controller;
using InitialEnterprise.BlazorFrontend.Pages.Person.Address;
using Blazored.Modal;
using InitialEnterprise.BlazorFrontend.Pages.Currency;
using Microsoft.AspNetCore.Components.Authorization;

namespace InitialEnterprise.BlazorFrontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddSingleton<ApiSettings>();

            
            services.AddRazorPages();
            services.AddBlazoredModal(); 
            services.AddServerSideBlazor();
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

            services.AddScoped<CurrencyController>();
            services.AddScoped<ICurrencyService,CurrencyService>();

            services.AddScoped<UserController>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<PersonController>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<CreditCardController>();
            services.AddScoped<ICreditCardService, CreditCardService>();

            services.AddScoped<EmailAddressController>();
            services.AddScoped<IEmailAddressService, EmailAddressService>();

            services.AddScoped<AddressController>();
            services.AddScoped<IPersonAddressService, PersonAddressService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
