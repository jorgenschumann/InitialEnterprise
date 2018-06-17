using System.Threading;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Api.Middlewares;
using InitialEnterprise.Infrastructure.IoC;
using MediatR;
using MediatR.Pipeline;
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

        public static void ConfigureDatabase(IServiceCollection services, string connectionString, Container container)
        {
            var contextOptions = new DbContextOptionsBuilder<MainDbContext>().UseInMemoryDatabase(connectionString).Options;

            services.AddDbContext<MainDbContext>(options => { options.UseSqlServer(connectionString); });

            container.Register(() => { return contextOptions; }, Lifestyle.Scoped);

            container.Register(() => { return new MainDbContext(contextOptions, new NoMediator() ); }, Lifestyle.Scoped);

            container.Register<IMainDbContext, MainDbContext>(Lifestyle.Scoped);
        }

        private void ConfigureEntityFrameworkContext(IServiceCollection services)
        {
            if (hostingEnvironment.IsEnvironment("Test"))
            {

            }
            else
            {
                ConfigureDatabase(services, Configuration.GetConnectionString("InitialEnterprise"), container);
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            InitializeContainer(services);

            var mvcBuilder = services.AddMvc();
            ConfigureJsonSerializer(mvcBuilder);

            services.AddCors();

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

        private void InitializeContainer(IServiceCollection services)
        {
            this.container = new IoCContainerBuilder(new AsyncScopedLifestyle()).Initialize();
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
    }   
}
