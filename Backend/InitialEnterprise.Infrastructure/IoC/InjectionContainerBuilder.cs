using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD;
using InitialEnterprise.Infrastructure.Repository;
using SimpleInjector;

namespace InitialEnterprise.Infrastructure.IoC
{
    public class InjectionContainerBuilder
    {
        private Container container;

        public InjectionContainerBuilder(ScopedLifestyle defaultScopedLifestyle)
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = defaultScopedLifestyle;
        }

        public Container Initialize()
        {                      
            var assemblies = LoadAssemblies();

            RegisterContainerInjectables(assemblies, typeof(IInjectable));
        
            RegisterContainerOpenGenericInjectables(assemblies);

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

        private void RegisterContainerOpenGenericInjectables(IEnumerable<Assembly> assemblies)
        {
            var commandHandlerImplementation = container.GetTypesToRegister(typeof(ICommandHandlerWithAggregateAsync<>), assemblies);
            container.Register(typeof(ICommandHandlerWithAggregateAsync<>), commandHandlerImplementation);
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
