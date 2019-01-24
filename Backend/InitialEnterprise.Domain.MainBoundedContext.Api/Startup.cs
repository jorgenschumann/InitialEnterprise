using InitialEnterprise.Domain.MainBoundedContext.Api.Controller;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Api.Filter;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            services.ConfigureServiceCollection();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsBuilder => corsBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApplicationDefinitions.SwaggerVersion, new Info
                {
                    Title = ApplicationDefinitions.SwaggerTitle,
                    Version = ApplicationDefinitions.SwaggerVersion
                });
            });

            ConfigureJsonSerializer(builder);

            ConfigureEntityFrameworkContext(services);

            //todo: make a method ConfigureAuthService
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
                options.RequireHttpsMetadata = true;
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
                options.AddPolicy(CurrencyClaims.CurrencyRead, policy => policy.Requirements.Add(new ClaimRequirement("Currency", "Read")));
                options.AddPolicy(CurrencyClaims.CurrencyQuery, policy => policy.Requirements.Add(new ClaimRequirement("Currency", "List")));
                options.AddPolicy(CurrencyClaims.CurrencyWrite, policy => policy.Requirements.Add(new ClaimRequirement("Currency", "Write")));

                options.AddPolicy(PersonClaims.PersonRead, policy => policy.Requirements.Add(new ClaimRequirement("Person", "Read")));
                options.AddPolicy(PersonClaims.PersonWrite, policy => policy.Requirements.Add(new ClaimRequirement("Person", "Write")));
                options.AddPolicy(PersonClaims.PersonCreate, policy => policy.Requirements.Add(new ClaimRequirement("Person", "Create")));
            });
        }

        public virtual void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            ConfigureLogger(loggerFactory);

            if (hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowAnyOrigin();
                    c.AllowCredentials();
                });
            }

            if (hostingEnvironment.IsEnvironment(ApplicationDefinitions.HostingEnvironmentTest))
            {
                var context = app.ApplicationServices.GetService<MainDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.EnsureTestdataSeeding();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(
                ApplicationConfigKeys.InitialEnterpriseConnectionString);

            var contextOptions = new DbContextOptionsBuilder<MainDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public void ConfigureTestDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(
                ApplicationConfigKeys.InitialEnterpriseInMemoryConnectionString);

            var contextOptions = new DbContextOptionsBuilder<MainDbContext>()
                .UseInMemoryDatabase(connectionString)
                .Options;

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });
        }

        private void ConfigureEntityFrameworkContext(IServiceCollection services)
        {
            if (hostingEnvironment.IsDevelopment() ||
                hostingEnvironment.IsEnvironment(ApplicationDefinitions.HostingEnvironmentTest))
            {
                ConfigureTestDatabase(services);
            }

            if (hostingEnvironment.IsProduction() ||
                hostingEnvironment.IsStaging())
            {
                ConfigureDatabase(services);
            }
        }

        private static void ConfigureJsonSerializer(IMvcCoreBuilder mvcBuilder)
        {
            mvcBuilder.AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        private void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection(ApplictionConfigSections.Logging));
            loggerFactory.AddDebug();
        }
    }
}