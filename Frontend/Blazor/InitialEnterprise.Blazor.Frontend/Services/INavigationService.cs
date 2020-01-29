using InitialEnterprise.Frontend.Models;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface INavigationService
    {
        Task<NavigationDto> GetUserNavigation(Guid userId);

        NavigationDto GetPosibleNavigation();
    }  
}
