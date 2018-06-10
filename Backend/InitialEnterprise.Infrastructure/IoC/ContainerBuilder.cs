using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InitialEnterprise.Domain.SharedKernel;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.Repository;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace InitialEnterprise.Infrastructure.IoC
{
    public class ContainerBuilder
    {
        private Container container;

        public ContainerBuilder(ScopedLifestyle defaultScopedLifestyle)
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

            container.Register(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            container.Register(typeof(ICommandHandler<>), assemblies);

            return container;
        }

        private void RegisterContainerInjectables(Assembly[] assemblies, Type interfaceType)
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
