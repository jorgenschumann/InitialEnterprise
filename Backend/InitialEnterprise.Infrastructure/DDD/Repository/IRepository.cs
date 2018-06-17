using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.DDD.Repository
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task SaveAsync(T aggregate);

        Task<T> GetByIdAsync(Guid id);
    }
}