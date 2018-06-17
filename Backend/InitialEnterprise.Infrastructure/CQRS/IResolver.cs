using System.Collections.Generic;

namespace InitialEnterprise.Infrastructure.CQRS
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
