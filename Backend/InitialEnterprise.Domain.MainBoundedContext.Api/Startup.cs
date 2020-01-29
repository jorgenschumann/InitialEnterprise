using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
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
            services.ConfigureServiceCollection();
            
            services.AddCors();

            ConfigureTestDatabase(services);

            var jwtAuthenticationSettings = Configuration.GetSection("JwtAuthentication");
            services.Configure<JwtAuthentication>(jwtAuthenticationSettings);
            var jwtAuthentication = jwtAuthenticationSettings.Get<JwtAuthentication>();


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtAuthentication.ValidAudience,
                    ValidIssuer = jwtAuthentication.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthentication.SecurityKey))
                };
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Todo: make it more generic
            services.AddAuthorization(options =>
            {
                options.AddPolicy(CurrencyCreateClaim.PolicyName, policy => policy.Requirements.Add(new CurrencyCreateClaim().ClaimRequirement));
                options.AddPolicy(CurrencyReadClaim.PolicyName, policy => policy.Requirements.Add(new CurrencyReadClaim().ClaimRequirement));
                options.AddPolicy(CurrencyWriteClaim.PolicyName, policy => policy.Requirements.Add(new CurrencyWriteClaim().ClaimRequirement));
                options.AddPolicy(CurrencyQueryClaim.PolicyName, policy => policy.Requirements.Add(new CurrencyQueryClaim().ClaimRequirement));
                options.AddPolicy(CurrencyDeleteClaim.PolicyName, policy => policy.Requirements.Add(new CurrencyDeleteClaim().ClaimRequirement));

                options.AddPolicy(PersonReadClaim.PolicyName, policy => policy.Requirements.Add(new PersonReadClaim().ClaimRequirement));
                options.AddPolicy(PersonWriteClaim.PolicyName, policy => policy.Requirements.Add(new PersonWriteClaim().ClaimRequirement));
                options.AddPolicy(PersonCreateClaim.PolicyName, policy => policy.Requirements.Add(new PersonCreateClaim().ClaimRequirement));
                options.AddPolicy(PersonQueryClaim.PolicyName, policy => policy.Requirements.Add(new PersonQueryClaim().ClaimRequirement));

                options.AddPolicy(ClaimQuery.PolicyName, policy => policy.Requirements.Add(new ClaimQuery().ClaimRequirement));

            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Test"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors();
        }

        public void ConfigureTestDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(
                AppsettingsKeys.InitialEnterpriseInMemoryConnectionString);

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            var context = services.BuildServiceProvider().GetService<MainDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.EnsureTestdataSeeding();
        }
    }
}
