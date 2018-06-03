using System;


namespace InitialEnterprise.Infrastructure.CQRS.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandHandlerAttribute : Attribute
    {
    }
}
