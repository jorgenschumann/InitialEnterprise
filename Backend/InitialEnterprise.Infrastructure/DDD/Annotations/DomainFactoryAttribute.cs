using System;

namespace InitialEnterprise.Infrastructure.DDD.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DomainFactoryAttribute : Attribute
    {
    }
}
