using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InitialEnterprise.Domain.SharedKernel;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.Behaviors;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.Repository;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace InitialEnterprise.Infrastructure.IoC
{
    public class IoCContainerBuilder
    {
        private Container container;

        public IoCContainerBuilder(ScopedLifestyle defaultScopedLifestyle)
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = defaultScopedLifestyle;
        }

        public Container Initialize()
        {                      
            var assemblies = LoadAssemblies();
                  
            //RegisterContext(assemblies, typeof(IInjectableUnitOfWork));
            RegisterContainerInjectables(assemblies, typeof(IInjectableRepository));
            RegisterContainerInjectables(assemblies, typeof(IInjectableDomainService));
            RegisterContainerInjectables(assemblies, typeof(IInjectableApplicationService));

            
            return container;
        }

         void RegisterContainerInjectables(Assembly[] assemblies, Type interfaceType)
        {
            var implementations = FindInjectableImplementation(assemblies, interfaceType);

            foreach (var implementation in implementations)
            {
                var registrationInterface = GetInterfacesWithoutInheritance(implementation).First();

                container.Register(registrationInterface, implementation);
            }
        }
        private void RegisterContext(Assembly[] assemblies, Type interfaceType)
        {
            var implementations = FindInjectableImplementation(assemblies, interfaceType);

            foreach (var implementation in implementations)
            {
                var registrationInterface = GetInterfacesWithoutInheritance(implementation).First();
                var registration =  Lifestyle.Singleton.CreateRegistration(implementation, container);
                container.AddRegistration(registrationInterface, registration);
            }           
        }

        private void RegisterCommandPipeline()
        {
            container.RegisterSingleton<IMediator, Mediator>();
        }

    
        ////https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.SimpleInjector/Program.cs
        //private IMediator BuildMediator(Assembly[] assemblies)
        //{            
        //    container.RegisterSingleton<IMediator, Mediator>();
        //    container.Register(typeof(IRequestHandler<,>), assemblies);

        //     var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
        //    {
        //        IncludeGenericTypeDefinitions = true,
        //        IncludeComposites = false
        //    });

        //    container.Register(typeof(INotificationHandler<>), notificationHandlerTypes);
             
        //    //Pipeline
        //    container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
        //    {
        //        typeof(RequestPreProcessorBehavior<,>),
        //        typeof(RequestPostProcessorBehavior<,>)
        //    });

        //    //container.Register(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        //    //container.Register(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

        //    //container.Collection.Register(typeof(IRequestPreProcessor<>), new[] { typeof(GenericRequestPreProcessor<>) });
        //    //container.Collection.Register(typeof(IRequestPostProcessor<,>), new[] { typeof(GenericRequestPostProcessor<,>), typeof(ConstrainedRequestPostProcessor<,>) });

        //    container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
            
        //    return container.GetInstance<IMediator>();         
        //}

        private IEnumerable<Type> GetInterfacesWithoutInheritance(Type type)
        {
            return type.BaseType == null ? type.GetInterfaces() : type.GetInterfaces().Except(type.BaseType.GetInterfaces());
        }

        private IEnumerable<Type> FindInjectableImplementation(Assembly[] assemblies, Type interfaceType)
        {
            var injectables = assemblies.SelectMany(x => x.GetExportedTypes())
                .Where(type => type.IsClass && interfaceType.IsAssignableFrom(type));

            return injectables;
        }

        public Assembly[] LoadAssemblies()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> appAssemblies = new List<Assembly>();
            List<string> assemblyFiles = Directory.GetFiles(path, "InitialEnterprise.*.dll").Select(filePath => Path.GetFileNameWithoutExtension(filePath)).ToList();
            foreach (string dllFileName in assemblyFiles)
            {
                appAssemblies.Add(Assembly.Load(new AssemblyName(dllFileName)));
            }
            return appAssemblies.ToArray();
        }

        private Assembly[] ListAssemblies()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("InitialEnterprise"))
                .ToArray();
        }
    }

}
