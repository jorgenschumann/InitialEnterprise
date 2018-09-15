using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryUserHandlerAsync :
        IQueryHandlerAsync<UserQuery, ApplicationUser>,
        IQueryHandlerAsync<UserQuery,IEnumerable<ApplicationUser>>
    {
        readonly UserManager<ApplicationUser> userManager;

        public QueryUserHandlerAsync(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> RetrieveAsync(UserQuery query)
        {
            return await userManager.Users.Where(u => u.Id == query.Id).ToAsyncEnumerable().First();
        }
          
        async  Task<IEnumerable<ApplicationUser>> IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>.RetrieveAsync(UserQuery query)
        {
            return await userManager.Users.ToAsyncEnumerable().ToList();
        }
    }    
}