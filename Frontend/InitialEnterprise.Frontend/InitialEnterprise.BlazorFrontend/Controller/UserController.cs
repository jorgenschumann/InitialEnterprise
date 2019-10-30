using InitialEnterprise.BlazorFrontend.Pages.User;
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
        
        private UserEditView userEditView;
        public void SetView(UserEditView userEditView)
        {
            this.userEditView = userEditView;
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            using (busyIndicatorService.Show())
            {                
                return await userService.Get();
            }
        }

        public async Task Get(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                userEditView.User = await userService.Get(id);
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
