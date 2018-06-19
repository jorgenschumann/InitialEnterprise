using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.CQRS.Queries
{
    public interface IQueryProcessorAsync
    {
        Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
