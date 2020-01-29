using System.Text;
using InitialEnterprise.Domain.IndentityBoundedContext.Api.Extensions;
using InitialEnterprise.Domain.IndentityBoundedContext.EntityFramework;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServiceCollection();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        corsBuilder => corsBuilder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:62758/")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            ConfigureTestDatabase(services);

            services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            }
            ).AddEntityFrameworkStores<MainDbContext>().AddDefaultTokenProviders();

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

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserQueryClaim.PolicyName, policy => policy.Requirements.Add(new UserQueryClaim().ClaimRequirement));
                options.AddPolicy(UserReadClaim.PolicyName, policy => policy.Requirements.Add(new UserReadClaim().ClaimRequirement));
                options.AddPolicy(UserWriteClaim.PolicyName, policy => policy.Requirements.Add(new UserWriteClaim().ClaimRequirement));
                options.AddPolicy(UserCreateClaim.PolicyName, policy => policy.Requirements.Add(new UserCreateClaim().ClaimRequirement));
                options.AddPolicy(UserDeleteClaim.PolicyName, policy => policy.Requirements.Add(new UserDeleteClaim().ClaimRequirement));

                options.AddPolicy(ClaimQuery.PolicyName, policy => policy.Requirements.Add(new ClaimQuery().ClaimRequirement));
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Test"))
            {
                app.UseDeveloperExceptionPage();
            }
            
            //app.UseHttpsRedirection();
            app.UseRouting();         
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("CorsPolicy");
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
