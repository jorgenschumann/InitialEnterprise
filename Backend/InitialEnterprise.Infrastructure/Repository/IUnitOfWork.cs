using System.Threading;
using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
