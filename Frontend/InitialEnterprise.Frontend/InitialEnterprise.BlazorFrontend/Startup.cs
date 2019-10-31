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
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage();
            services.AddAuthenticationCore();
            services.AddAuthorizationCore();
            services.AddScoped<HttpClient>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<BusyIndicatorService>();
            services.AddScoped<IBusyIndicatorService>(p => p.GetRequiredService<BusyIndicatorService>());
            services.AddScoped<MessageBoxService>();
            services.AddScoped<IMessageBoxService>(p => p.GetRequiredService<MessageBoxService>());
            services.AddScoped<INavigationManager, AppNavigationManager>();
            
            services.AddScoped<CurrencyController>();
            services.AddScoped<ICurrencyService,CurrencyService>();  

            services.AddScoped<AuthenticationController>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();       
                  
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