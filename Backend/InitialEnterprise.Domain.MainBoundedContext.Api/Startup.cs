using InitialEnterprise.Domain.MainBoundedContext.Api.Controller;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

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
            var jwtAuthenticationSettings = Configuration.GetSection("JwtAuthentication");
            services.Configure<JwtAuthentication>(jwtAuthenticationSettings);

            var builder = services.AddMvcCore();

            services.ConfigureServiceCollection();                      
            
            services.AddMvc(options => {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices();                      

            var jwtAuthentication = jwtAuthenticationSettings.Get<JwtAuthentication>();           

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

            services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
             {
                 option.Password.RequireDigit = false;
                 option.Password.RequiredLength = 6;
                 option.Password.RequireNonAlphanumeric = false;
                 option.Password.RequireUppercase = false;
                 option.Password.RequireLowercase = false;
             }
             ).AddEntityFrameworkStores<MainDbContext>().AddDefaultTokenProviders();

                services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
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
                options.AddPolicy(ClaimDefinitions.CurrencyRead, policy => policy.Requirements.Add(
                    new ClaimRequirement("Currency", "Read")));
                options.AddPolicy(ClaimDefinitions.CurrencyQuery, policy => policy.Requirements.Add(
                   new ClaimRequirement("Currency", "List")));
                options.AddPolicy(ClaimDefinitions.CurrencyWrite, policy => policy.Requirements.Add(
                    new ClaimRequirement("Currency", "Write")));

                options.AddPolicy(ClaimDefinitions.PersonRead, policy => policy.Requirements.Add(
                    new ClaimRequirement("Person", "Read")));
                options.AddPolicy(ClaimDefinitions.PersonWrite, policy => policy.Requirements.Add(
                    new ClaimRequirement("Person", "Write")));
                options.AddPolicy(ClaimDefinitions.PersonCreate, policy => policy.Requirements.Add(
                    new ClaimRequirement("Person", "Create")));
            });
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
                    c.AllowCredentials();
                });
            }
          
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseAuthentication();

            applicationBuilder.UseMvc();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseSwagger();

        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(ApplicationConfigKeys.InitialEnterpriseConnectionString);

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
                ConfigureTestDatabase(services);//ConfigureDatabase(services);
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