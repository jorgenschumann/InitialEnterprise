using AutoMapper;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Api.Middlewares;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterpriseTests.DataSeeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private Container container;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        public virtual void Configure(IApplicationBuilder applicationBuilder)
        {
            RegisterMvcControllersInContainer(applicationBuilder, container);

            ConfigureAutoMapper();

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

            container.RegisterInstance(Configuration);

            container.Verify();

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseMvc();

            applicationBuilder.UseSwagger();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("InitialEnterprise");

            var contextOptions = new DbContextOptionsBuilder<MainDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            container.Register(() => contextOptions, Lifestyle.Singleton);

            container.Register(() => new MainDbContext(contextOptions), Lifestyle.Singleton);
        }

        public void ConfigureTestDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("InitialEnterpriseInMemory");

            var contextOptions = new DbContextOptionsBuilder<MainDbContext>()
                .UseInMemoryDatabase(connectionString)
                .Options;

            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            container.Register(() => contextOptions, Lifestyle.Singleton);

            container.Register(() =>
            {
                var context = new MainDbContext(contextOptions);
                var currencySeed = SeedDataBuilder.BuildCurrencies();

                foreach (var currency in currencySeed)
                {
                    currency.ApplyEvents(SeedDataBuilder.BuildEntities<DomainEvent>(10));
                }

                context.Currencies.AddRange(currencySeed);
                context.SaveChanges();

                return context;

            }, Lifestyle.Singleton);
        }

        private void ConfigureEntityFrameworkContext(IServiceCollection services)
        {
            if (hostingEnvironment.IsEnvironment("Test"))
            {
                ConfigureTestDatabase(services);
            }
            else
            {
                ConfigureDatabase(services);
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            InitializeContainer();

            var mvcBuilder = services.AddMvc();
            ConfigureJsonSerializer(mvcBuilder);

            services.AddCors();

            services.AddMvc();

            RegisterControllerActivators(services, container);

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "InitialEnterprise API V1", Version = "v1" }); });

            services.EnableSimpleInjectorCrossWiring(container);

            ConfigureEntityFrameworkContext(services);
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

        private static void RegisterControllerActivators(IServiceCollection services, Container injectionContainer)
        {
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(injectionContainer));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(injectionContainer));
            services.UseSimpleInjectorAspNetRequestScoping(injectionContainer);
        }

        private void InitializeContainer()
        {
            this.container = new InjectionContainerBuilder(new AsyncScopedLifestyle()).Initialize();
        }

        private void RegisterMvcControllersInContainer(IApplicationBuilder applicationBuilder, Container injectionContainer)
        {
            injectionContainer.RegisterMvcControllers(applicationBuilder);
            injectionContainer.RegisterMvcViewComponents(applicationBuilder);
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration.GetValue<bool>("UseLoadTest"))
            {
                app.UseMiddleware<AuthenticationByPassMiddleware>();
            }

            app.UseAuthentication();
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<CurrencyDto, CreateCurrencyCommand>();
                cfg.CreateMap<Currency, CurrencyDto>();
                cfg.CreateMap<IDomainEvent, DomainEventDto>();
            });
        }
    }
}