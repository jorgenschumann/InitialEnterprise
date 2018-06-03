using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
                  where type.IsDefined(typeof(DomainServiceAttribute))
                  select new { Service = type.GetInterfaces().Single(), Implementation = type };

                foreach (var registrationCandidate in registrations)
                {
                    container.Register(registrationCandidate.Service, registrationCandidate.Implementation, Lifestyle.Transient);
                }
            }

            return container;
        } 

        private Assembly[] ListAssemblies()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;

            return currentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("InitialEnterprise")).ToArray();
        }
    }
}
