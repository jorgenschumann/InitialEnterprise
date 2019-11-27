using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Repository
{
    public interface IUserNavigationRepository
    {
        Task<UserNavigation> Query(UserQuery query);
    }
}
