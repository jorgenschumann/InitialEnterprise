using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.IoC;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace InitialEnterprise.Infrastructure.CQRS
{
    public class Resolver : IResolver, IInjectable
    {
        private readonly IServiceProvider serviceProvider;

        public Resolver(Container serviceProvider)//, IHttpContextAccessor httpContextAccessor)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return serviceProvider.GetServices<T>();
        }
    }
}