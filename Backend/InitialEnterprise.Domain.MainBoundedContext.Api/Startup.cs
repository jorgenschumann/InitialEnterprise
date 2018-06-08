using InitialEnterprise.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class Startup
    {
        private readonly Container container;
        
        public Startup()
        {
            container = new ContainerBuilder().Initialize();          
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddMvc();

            services.EnableSimpleInjectorCrossWiring(container);

            RegisterControllerActivators(services, container);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            //container.AutoCrossWireAspNetComponents(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InitialEnterprise API V1");
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);
            //container.AutoCrossWireAspNetComponents(app);
        }

        private static void RegisterControllerActivators(IServiceCollection services, Container injectionContainer)
        {
            services.AddSingleton<Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator>(new SimpleInjectorControllerActivator(injectionContainer));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(injectionContainer));
        }

    }
}
