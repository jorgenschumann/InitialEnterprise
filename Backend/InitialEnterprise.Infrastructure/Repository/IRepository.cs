namespace InitialEnterprise.Infrastructure.Repository
{
    public interface IRepository<T> where T : IEntity // IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }  
}
