using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Queries;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.QueryHandler
{
    public class QueryUserHandlerAsync :
        IQueryHandlerAsync<UserQuery, ApplicationUser>,
        IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>,
        IQueryHandlerAsync<UserQuery, IList<Claim>>
    {

        private readonly UserManager<ApplicationUser> userManager;
      
        public QueryUserHandlerAsync(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        
        public async Task<ApplicationUser> Retrieve(UserQuery query)
        {
            return userManager.Users.Where(u => u.Id == query.Id).ToList().First();
        }

        async Task<IEnumerable<ApplicationUser>> IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>.Retrieve(UserQuery query)
        {
            return userManager.Users.ToList();
        }

        async Task<IList<Claim>> IQueryHandlerAsync<UserQuery, IList<Claim>>.Retrieve(UserQuery query)
        {
            var user = await Retrieve(query);
            return await userManager.GetClaimsAsync(user);
        }
    }
}