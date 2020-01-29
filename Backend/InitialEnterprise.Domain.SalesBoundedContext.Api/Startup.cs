using InitialEnterprise.Domain.SalesBoundedContext.Api.Seeding;
using InitialEnterprise.Domain.SalesBoundedContext.EntityFramework;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InitialEnterprise.Domain.SalesBoundedContext.Api
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
                options.AddPolicy(CustomerReadClaim.PolicyName, policy => policy.Requirements.Add(new CustomerReadClaim().ClaimRequirement));
                options.AddPolicy(CustomerWriteClaim.PolicyName, policy => policy.Requirements.Add(new CustomerWriteClaim().ClaimRequirement));
                options.AddPolicy(CustomerCreateClaim.PolicyName, policy => policy.Requirements.Add(new CustomerCreateClaim().ClaimRequirement));
                options.AddPolicy(CustomerQueryClaim.PolicyName, policy => policy.Requirements.Add(new CustomerQueryClaim().ClaimRequirement));
                options.AddPolicy(CustomerDeleteClaim.PolicyName, policy => policy.Requirements.Add(new CustomerDeleteClaim().ClaimRequirement));

                options.AddPolicy(ClaimQuery.PolicyName, policy => policy.Requirements.Add(new ClaimQuery().ClaimRequirement));

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InitialEnterprise.Indentity.Api", Version = "v1" });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Test"))
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "InitialEnterprise Indentity Api");
            });
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

            services.AddDbContext<SalesDbContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            var context = services.BuildServiceProvider().GetService<SalesDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.EnsureTestdataSeeding();
        }
    }
}
