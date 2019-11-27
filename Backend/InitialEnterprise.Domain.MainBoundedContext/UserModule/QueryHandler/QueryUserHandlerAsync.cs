using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryUserHandlerAsync :
        IQueryHandlerAsync<UserQuery, ApplicationUser>,
        IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>,
        IQueryHandlerAsync<UserQuery, UserNavigation>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserNavigationRepository userNavigationRepository;

        public QueryUserHandlerAsync(UserManager<ApplicationUser> userManager, 
            IUserNavigationRepository userNavigationRepository)
        {
            this.userManager = userManager;
            this.userNavigationRepository = userNavigationRepository;
        }

        public async Task<ApplicationUser> Retrieve(UserQuery query)
        {
            return await userManager.Users.Where(u => u.Id == query.Id).ToAsyncEnumerable().First();
        }

        async Task<IEnumerable<ApplicationUser>> IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>.Retrieve(UserQuery query)
        {
            return await userManager.Users.ToAsyncEnumerable().ToList();
        }

        async Task<UserNavigation> IQueryHandlerAsync<UserQuery, UserNavigation>.Retrieve(UserQuery query)
        {
            return await userNavigationRepository.Query(query);
        }
    }
}