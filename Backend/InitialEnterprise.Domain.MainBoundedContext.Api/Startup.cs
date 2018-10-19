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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{

    public class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly IOptions<JwtAuthentication> _jwtAuthentication;

        public ConfigureJwtBearerOptions(IOptions<JwtAuthentication> jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication ?? throw new ArgumentNullException(nameof(jwtAuthentication));
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            var jwtAuthentication = _jwtAuthentication.Value;

            options.ClaimsIssuer = jwtAuthentication.ValidIssuer;
            options.IncludeErrorDetails = true;
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateActor = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtAuthentication.ValidIssuer,
                ValidAudience = jwtAuthentication.ValidAudience,
                IssuerSigningKey = jwtAuthentication.SymmetricSecurityKey,
                NameClaimType = ClaimTypes.NameIdentifier
            };
        }
    }

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtAuthentication:ValidIssuer"],
                        ValidAudience = Configuration["JwtAuthentication:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JwtAuthentication:SecurityKey"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TrainedStaffOnly",
                    policy => policy.RequireClaim("CompletedBasicTraining"));
            });
                  
            services.AddMvc(options => {
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

            ConfigureEntityFrameworkContext(services);
           
            services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<MainDbContext>()
               .AddDefaultTokenProviders();      

            //services.Configure<JwtAuthentication>(Configuration.GetSection("JwtAuthentication"));

            //services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>,ConfigureJwtBearerOptions>();                      

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddSingleton<IAuthorizationHandler, ClaimsAuthorizationHandler>();

            ////Todo: make it more generic
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(ClaimDefinitions.CurrencyRead, policy => policy.Requirements.Add(
            //        new ClaimRequirement("Currency", "Read")));
            //    options.AddPolicy(ClaimDefinitions.CurrencyWrite, policy => policy.Requirements.Add(
            //        new ClaimRequirement("Currency", "Write")));

            //    options.AddPolicy(ClaimDefinitions.PersonRead, policy => policy.Requirements.Add(
            //        new ClaimRequirement("Person", "Read")));

            //    options.AddPolicy(ClaimDefinitions.PersonWrite, policy => policy.Requirements.Add(
            //        new ClaimRequirement("Person", "Write")));

            //    options.AddPolicy(ClaimDefinitions.PersonCreate, policy => policy.Requirements.Add(
            //        new ClaimRequirement("Person", "Create")));
            //});        
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

            //applicationBuilder.UseMiddleware<AuthenticatedTestRequestMiddleware>();
            
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseMvc();
            applicationBuilder.UseStaticFiles();
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
                ConfigureTestDatabase(services);//ConfigureDatabase(services);
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