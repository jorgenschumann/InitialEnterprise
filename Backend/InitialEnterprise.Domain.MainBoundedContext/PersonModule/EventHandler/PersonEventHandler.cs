using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Events;
using InitialEnterprise.Infrastructure.CQRS.Events;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.EventHandler
{
    public class PersonEventHandler :
        IEventHandlerAsync<PersonAddressCreateDomainEvent>,
        IEventHandlerAsync<PersonAddressDeletedDomainEvent>,
        IEventHandlerAsync<PersonAddressUpdateDomainEvent>,
        IEventHandlerAsync<PersonCreatedDomainEvent>,
        IEventHandlerAsync<PersonEmailAddressCreateDomainEvent>,
        IEventHandlerAsync<PersonEmailAddressDeletedDomainEvent>,
        IEventHandlerAsync<PersonEmailAddressUpdateDomainEvent>,
        IEventHandlerAsync<PersonUpdatedByNewEmailAddressDomainEvent>,
        IEventHandlerAsync<PersonUpdatedByRemoveEmailAddressDomainEvent>,
        IEventHandlerAsync<PersonUpdatedDomainEvent>
    {
        public async Task HandleAsync(PersonAddressCreateDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonAddressDeletedDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonAddressUpdateDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonCreatedDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonEmailAddressCreateDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonEmailAddressDeletedDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonEmailAddressUpdateDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonUpdatedByNewEmailAddressDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonUpdatedByRemoveEmailAddressDomainEvent @event)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(PersonUpdatedDomainEvent @event)
        {
            await Task.CompletedTask;
        }
    }    
}
