using InitialEnterprise.Domain.MainBoundedContext.Api.Controller;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Filter;
using InitialEnterprise.Infrastructure.Api.Middlewares;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IHostingEnvironment env;


        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        public Startup(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServiceCollection();

            var mvcBuilder = services.AddMvc();

            ConfigureJsonSerializer(mvcBuilder);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
                .AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApplicationDefinitions.SwaggerVersion, new Info
                {
                    Title = ApplicationDefinitions.SwaggerTitle,
                    Version = ApplicationDefinitions.SwaggerVersion
                });
            });

            ConfigureEntityFrameworkContext(services);

            //https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-2.1
            services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<MainDbContext>()
               .AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
            );

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsAuthorizationHandler>();
            
            //Todo: make it more generic
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ClaimDefinitions.CurrencyRead, policy => policy.Requirements.Add(
                    new ClaimRequirement("Currency", "Read")));

                options.AddPolicy(ClaimDefinitions.CurrencyWrite, policy => policy.Requirements.Add(
                    new ClaimRequirement("Currency", "Write")));

            });

            // ConfigureAuthService(services);
        }

        public virtual void Configure(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory)
        {
            ConfigureLogger(loggerFactory);

            if (hostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();

                applicationBuilder.UseCors(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowAnyOrigin();
                });
            }

            applicationBuilder.UseMiddleware<AuthenticatedTestRequestMiddleware>();

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseMvc();

            applicationBuilder.UseSwagger();

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

            services.AddSingleton(mainContext =>
            {
                var context = new MainDbContext(contextOptions);
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.EnsureTestdataSeeding();
                return context;
            });

        }

        private void ConfigureEntityFrameworkContext(IServiceCollection services)
        {
            if (hostingEnvironment.IsEnvironment(ApplicationDefinitions.HostingEnvironmentTest))
            {
                ConfigureTestDatabase(services);
            }
            else
            {
                ConfigureDatabase(services);
            }
        }

        private static void ConfigureJsonSerializer(IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        private void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection(ApplictionConfigSections.Logging));
            loggerFactory.AddDebug();
        }
    }
}