using System;
using System.Linq;
using System.Reflection;
using InitialEnterprise.Domain.SharedKernel;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Annotations;
using SimpleInjector;

namespace InitialEnterprise.Infrastructure.IoC
{
    public class ContainerBuilder
    {
        public Container Initialize()
        {
            var container = new Container();
            var assemblies = ListAssemblies();

            foreach (var assembly in assemblies)
            {
                var registrations =
                  from type in assembly.GetExportedTypes()
                  where type.IsDefined(typeof(DomainServiceAttribute)) ||
                        type.IsDefined(typeof(DomainRepositoryAttribute))

                  select new { Service = type.GetInterfaces().Single(), Implementation = type };

                foreach (var registration in registrations)
                {
                    container.Register(registration.Service, registration.Implementation, Lifestyle.Transient);
                }
            }
            container.Register(typeof(ICommandDispatcher),typeof(CommandDispatcher));
            container.Register(typeof(ICommandHandler<>), assemblies);

            return container;
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
