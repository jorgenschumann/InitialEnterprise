using InitialEnterprise.BlazorFrontend.Infrastructure;
using InitialEnterprise.BlazorFrontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public class UserNavigationService : IUserNavigationService
    {      
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;
                
        public UserNavigationService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task<UserNavigationDto> GetUserNavigation(Guid userId)
        {
            return await requestService.GetAsync<UserNavigationDto>(
                 $"{apiSettings.Url}/UserAccount/{userId}/UserNavigation");
        }
    }
}
