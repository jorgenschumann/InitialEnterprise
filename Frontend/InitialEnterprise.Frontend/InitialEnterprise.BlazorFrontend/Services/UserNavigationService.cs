using InitialEnterprise.BlazorFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public interface IUserNavigationService
    {
        Task<UserNavigation> GetUserNavigation(Guid userId);
    }

    public class UserNavigationService : IUserNavigationService
    {
        public async Task<UserNavigation> GetUserNavigation(Guid userId)
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
