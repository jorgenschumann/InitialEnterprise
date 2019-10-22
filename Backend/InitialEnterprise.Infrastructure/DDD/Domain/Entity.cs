using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.Empty;
        }

        protected Entity(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
        }

        [JsonProperty]
        public Guid Id { get; protected set; }
    }
}