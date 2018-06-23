using System;
using System.Linq;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeapsyCqrs(this IServiceCollection services, params Type[] types)
        {
            // Convert to list and add IMediator.
            var typeList = types.ToList();
            typeList.Add(typeof(IDispatcher));

            //// Use Scrutor to register services
            //services.Scan(s => s
            //    .FromAssembliesOf(typeList)
            //    .AddClasses()
            //    .AsImplementedInterfaces());

            // Register repository
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}