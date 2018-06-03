using System;
using System.Collections.Generic;
using System.Linq;
using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Infrastructure.Repository
{

    public interface IRepository<TIdentity, TEntity> :
       IReadOnlyRepository<TIdentity, TEntity>,
       ISaveOnlyRepository<TEntity>,
       IDeleteOnlyRepository<TIdentity, TEntity> where TEntity : IEntity
    {
    }

    public interface IReadOnlyRepository<TIdentity, TEntity> : IDisposable where TEntity : IEntity
    {
        TEntity Read(TIdentity Id);
        IQueryable<TEntity> List(TIdentity Id);
    }

    public interface ISaveOnlyRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        void Save(TEntity entity);
        void Save(IEnumerable<TEntity> entities);
    }

    public interface IDeleteOnlyRepository<TIdentity, TEntity> : IDisposable where TEntity : IEntity
    {
        TEntity Delete(TEntity entity);       
    }  
}
