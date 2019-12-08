using InitialEnterprise.Blazor.Frontend.Models;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public interface INavigationService
    {
        Task<NavigationDto> GetUserNavigation(Guid userId);

        NavigationDto GetPosibleNavigation();
    }  
}
