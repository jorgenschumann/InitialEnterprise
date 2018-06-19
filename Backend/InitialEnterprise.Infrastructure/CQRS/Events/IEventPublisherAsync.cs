using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.CQRS.Events
{
    public interface IEventPublisherAsync
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
