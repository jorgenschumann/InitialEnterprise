using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Utils;

namespace InitialEnterprise.Infrastructure.CQRS.Queries
{
    public class QueryProcessorAsync : IQueryProcessorAsync, IInjectable
    {
        private readonly IResolver _resolver;

        public QueryProcessorAsync(IResolver resolver)
        {
            _resolver = resolver;
        }
        public async Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            Guard.AgainstArgumentNull(query);

            var handler = _resolver.Resolve<IQueryHandlerAsync<TQuery, TResult>>();

            Guard.AgainstNotNull<ArgumentException>(handler, $"No handler of type IQueryHandlerAsync<TQuery, TResult>> found for query '{query.GetType().FullName}'");

            return await handler.RetrieveAsync(query);
        }
    }
}