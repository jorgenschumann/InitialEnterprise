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
        IQueryHandlerAsync<UserQuery, IEnumerable<ApplicationUser>>,
        IQueryHandlerAsync<UserQuery, UserNavigation>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public QueryUserHandlerAsync(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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
            var group1Entries = new List<UserNavigationMenuGroupItem>
                {
                    new UserNavigationMenuGroupItem { DisplayName = "Currencies", Href = "currency/list" , Icon = "globe"},
                    new UserNavigationMenuGroupItem { DisplayName = "Users", Href = "user/list",Icon = "user" },
                    new UserNavigationMenuGroupItem { DisplayName = "People", Href = "person/list" ,Icon = "users"}
                };

            var group1 = new UserNavigationMenuGroup { DisplayName = "MainData", Entries = group1Entries };

            var userMenu = new UserNavigation();
            userMenu.Groups.Add(group1);

            return userMenu;
        }
    }
}