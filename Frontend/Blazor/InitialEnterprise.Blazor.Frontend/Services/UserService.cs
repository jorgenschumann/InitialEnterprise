using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public class UserService : IUserService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "UserAccount";

        public UserService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.IndentityUrl}/{Endpoint}/{id}");
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            return await requestService.GetAsync<List<UserDto>>(
                 $"{apiSettings.IndentityUrl}/{Endpoint}");
        }

        public async Task<UserDto> Get(Guid id)
        {
            return await requestService.GetAsync<UserDto>
                ($"{apiSettings.IndentityUrl}/{Endpoint}/{id}");
        }

        public async Task<List<ClaimDto>> GetClaims(Guid id)
        {
            return await requestService.GetAsync<List<ClaimDto>>
                ($"{apiSettings.IndentityUrl}/{Endpoint}/Claims/{id}");
        }

        public async Task<CommandHandlerAnswerDto<UserDto>> Post(UserDto user)
        {
            return await requestService.PostAsync<UserDto, CommandHandlerAnswerDto<UserDto>>(
              $"{apiSettings.IndentityUrl}/{Endpoint}", user);
        }

        public async Task<CommandHandlerAnswerDto<UserDto>> Put(UserDto user)
        {
            return await requestService.PutAsync<UserDto, CommandHandlerAnswerDto<UserDto>>(
                         $"{apiSettings.IndentityUrl}/{Endpoint}/{user.Id}", user);
        }
    }

}
