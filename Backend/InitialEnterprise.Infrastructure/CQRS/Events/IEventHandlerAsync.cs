using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.CQRS.Events
{
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
