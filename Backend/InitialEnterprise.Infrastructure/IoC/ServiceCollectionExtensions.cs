using System;
using System.IO;
using System.Linq;
using System.Reflection;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServiceCollection(this IServiceCollection services, params Type[] types)
        {
            var typeList = types.ToList();
            typeList.Add(typeof(IDispatcher));

            services.Scan(s => s
                .FromAssemblies(ListDirectoryAssemblies())
                .AddClasses()
                .AsImplementedInterfaces());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

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
    }
}