using System;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}