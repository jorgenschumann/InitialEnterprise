

using AgileObjects.AgileMapper;

namespace InitialEnterprise.Infrastructure.CQRS.Events
{
    public class EventFactory : IEventFactory
    {
        public dynamic CreateConcreteEvent(object @event)
        {
            var type = @event.GetType();

            dynamic result = Mapper.Map(@event).Over(System.Activator.CreateInstance(type));

            return result;
        }
    }
}