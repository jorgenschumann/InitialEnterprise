using InitialEnterprise.Blazor.Frontend.Services;
using InitialEnterprise.Blazor.Frontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Pages.Person
{
    public class PersonController
    {
        private readonly IPersonService personService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;
        private readonly NavigationManager navigationManager;

        public PersonController(
            IPersonService personService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService,
            NavigationManager navigationManager
            )
        {
            this.personService = personService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
            this.navigationManager = navigationManager;
        }

        public async Task<IEnumerable<PersonDto>> Get()
        {
            using (busyIndicatorService.Show())
            {                
                return await personService.Get();
            }
        }

        public async Task<PersonDto> Get(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                return await personService.Get(id);
            }
        }

        public async Task Delete(Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await personService.Delete(id);
                navigationManager.NavigateTo("/person/list");
            }
        }

        public async Task<CommandHandlerAnswerDto<PersonDto>> Save(PersonDto user)
        {            
            using (busyIndicatorService.Show())
            {
                if (user.Id != Guid.Empty){
                    return await personService.Put(user);
                }
                return await personService.Post(user);
            }          
        }
    }
}
