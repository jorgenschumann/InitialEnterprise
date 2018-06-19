﻿using System;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.Empty;
        }

        protected Entity(Guid id)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();

            Id = id;
        }        
    }
}
