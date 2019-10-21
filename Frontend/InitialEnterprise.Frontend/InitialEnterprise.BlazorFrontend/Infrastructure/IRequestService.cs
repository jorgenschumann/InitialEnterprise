using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Infrastructure
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri) where TResult : new();

        Task<TResult> PostAsync<TResult>(string uri, TResult data);

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data);

        Task<TResult> PutAsync<TResult>(string uri, TResult data);

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data);

        Task<TResult> DeleteAsync<TResult>(string uri);
    }
}
