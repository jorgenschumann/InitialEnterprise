using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public interface IUserNavigationService
    {
        Task<UserNavigationDto> GetUserNavigation(Guid userId);
    }
}
