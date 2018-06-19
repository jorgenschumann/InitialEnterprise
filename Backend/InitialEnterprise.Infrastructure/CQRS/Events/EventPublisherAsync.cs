using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Utils;

namespace InitialEnterprise.Infrastructure.CQRS.Events
{
    public class EventPublisherAsync : IEventPublisherAsync, IInjectable
    {
        private readonly IResolver _resolver;

        public EventPublisherAsync(IResolver resolver)
        {
            _resolver = resolver;
        }
      
        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        { 
           Guard.ArgumentNotNull(@event);

            var handlers = _resolver.ResolveAll<IEventHandlerAsync<TEvent>>();

            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);
            }
        }
    }
}
