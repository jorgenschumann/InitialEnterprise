using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace InitialEnterprise.Infrastructure.CQRS
{
    public class Resolver : IResolver
    {
        private readonly IServiceProvider serviceProvider;

        public Resolver(IServiceProvider serviceProvider)//, IHttpContextAccessor httpContextAccessor)
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