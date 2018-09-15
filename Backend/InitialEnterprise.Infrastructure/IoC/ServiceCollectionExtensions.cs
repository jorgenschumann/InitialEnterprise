using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServiceCollection(this IServiceCollection services)
        {
            services.Scan(s => s
                .FromAssemblies(ListDirectoryAssemblies())
                .AddClasses()
                .AsImplementedInterfaces());
      
            return services;
        }

        private static Assembly[] ListDirectoryAssemblies()
        {
            return
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory
                    , "InitialEnterprise.*.dll")
                    .Select(Path.GetFileNameWithoutExtension)
                    .Select(assemblyFile => Assembly.Load(new AssemblyName(assemblyFile)))
                    .ToArray();
        }

        public static ServiceDescriptor GetDescriptor<T>(this IServiceCollection services)
        {
            return services.GetDescriptors<T>().Single();
        }

        public static ServiceDescriptor[] GetDescriptors<T>(this IServiceCollection services)
        {
            return services.GetDescriptors(typeof(T));
        }

        public static ServiceDescriptor[] GetDescriptors(this IServiceCollection services, Type serviceType)
        {
            return services.Where(x => x.ServiceType == serviceType).ToArray();
        }
    }
}