using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Repository
{
    public class UserNavigationRepository : IUserNavigationRepository
    {

        private readonly IMainDbContext mainDbContext;

        public UserNavigationRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public async Task<UserNavigation> Query(UserQuery query)
        { 
            return await mainDbContext.UserNavigation
                .Include(x => x.Groups).ThenInclude(x => x.Entries)
                .FirstOrDefaultAsync(p => p.UserId == query.Id);
        }
    }
}
