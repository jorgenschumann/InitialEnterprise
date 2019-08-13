using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.CQRS.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Retrieve(TQuery query);
    }

    public interface IQueryHandlerAsync<TResult> 
    {
        Task<TResult> RetrieveAsync();
    }
}
