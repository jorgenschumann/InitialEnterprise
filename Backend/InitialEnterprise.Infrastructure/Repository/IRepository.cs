using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}