using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentValidation;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Decorators;
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
            var assemblies = ListDirectoryAssemblies();

            var listAssemblies = ListAssemblies();

            RegisterContainerInjectables(assemblies, typeof(IInjectable));

            //var foo = FindInjectableImplementation(ListDirectoryAssemblies(), typeof(IInjectable));
            //var bar = FindInjectableImplementation(ListAssemblies(), typeof(IInjectable));

            RegisterContainerOpenGenericInjectables(assemblies);

            return container;
        }

        private void RegisterContainerInjectables(Assembly[] assemblies, Type interfaceType)
        {
            var implementations = FindInjectableImplementation(assemblies, interfaceType);
            foreach (var implementation in implementations)
            {
                var registrationInterface = GetInterfacesWithoutInheritance(implementation).First();

                if (registrationInterface == typeof(IInjectable))
                {
                    container.Register(implementation);
                }
                else
                {
                    container.Register(registrationInterface, implementation);
                }
            }
        }

        private void RegisterContext(Assembly[] assemblies, Type interfaceType)
        {
            var implementations = FindInjectableImplementation(assemblies, interfaceType);

            foreach (var implementation in implementations)
            {
                var registrationInterface = GetInterfacesWithoutInheritance(implementation).First();
                var registration = Lifestyle.Singleton.CreateRegistration(implementation, container);
                container.AddRegistration(registrationInterface, registration);
            }
        }

        private void RegisterContainerOpenGenericInjectables(IEnumerable<Assembly> assemblies)
        {
            //TODO: make it dynamic

            var commandHandlerWithAggregateAsync = container.GetTypesToRegister(typeof(ICommandHandlerWithAggregateAsync<>), assemblies);
            container.Register(typeof(ICommandHandlerWithAggregateAsync<>), commandHandlerWithAggregateAsync);

            var commandHandlerWithEventsAsync = container.GetTypesToRegister(typeof(ICommandHandlerWithEventsAsync<>), assemblies);
            container.Register(typeof(ICommandHandlerWithEventsAsync<>), commandHandlerWithEventsAsync);

            var commandHandlerAsync = container.GetTypesToRegister(typeof(ICommandHandlerAsync<>), assemblies);
            container.Register(typeof(ICommandHandlerAsync<>), commandHandlerAsync);

            var commandValidator = container.GetTypesToRegister(typeof(IValidator<>), assemblies);
            container.Register(typeof(IValidator<>), commandValidator);

            container.RegisterDecorator(typeof(ICommandHandlerWithAggregateAsync<>), typeof(ValidationCommandHandlerDecorator<>));

            var queryHandlerAsync = container.GetTypesToRegister(typeof(IQueryHandlerAsync<,>), assemblies);
            container.Register(typeof(IQueryHandlerAsync<,>), queryHandlerAsync);
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

        private Assembly[] ListDirectoryAssemblies()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var appAssemblies = new List<Assembly>();
            var assemblyFiles =
                Directory.GetFiles(path, "InitialEnterprise.*.dll").Select(Path.GetFileNameWithoutExtension).ToList();
            foreach (string dllFileName in assemblyFiles)
            {
                appAssemblies.Add(Assembly.Load(new AssemblyName(dllFileName)));
            }
            return appAssemblies.ToArray();

            //return
            //    Directory.GetFiles
            //    (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            //        "InitialEnterprise*.dll").Select(Assembly.LoadFile).ToArray();
        }

        private Assembly[] ListAssemblies()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("InitialEnterprise."))
                .ToArray();
        }
    }
}