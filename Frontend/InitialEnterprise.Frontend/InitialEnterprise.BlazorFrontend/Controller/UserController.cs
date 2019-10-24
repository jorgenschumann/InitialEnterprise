using InitialEnterprise.BlazorFrontend.Services;
using InitialEnterprise.BlazorFrontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Controller
{
    public class UserController
    {
        private readonly IUserService userService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;
        private readonly NavigationManager navigationManager;

        public UserController(
            IUserService userService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService,
            NavigationManager navigationManager
            )
        {
            this.userService = userService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
            this.navigationManager = navigationManager;
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            using (busyIndicatorService.Show())
            {                
                return await userService.Get();
            }
        }

        public async Task<UserDto> Get(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                return await userService.Get(id);
            }
        }

        public async Task Delete(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await userService.Delete(id);
                navigationManager.NavigateTo("/user/list");
            }
        }

        public async Task<CommandHandlerAnswerDto<UserDto>> Save(UserDto user)
        {            
            using (busyIndicatorService.Show())
            {
                if (user.Id != Guid.Empty){
                    return await userService.Put(user);
                }
                return await userService.Post(user);
            }          
        }
    }
}
