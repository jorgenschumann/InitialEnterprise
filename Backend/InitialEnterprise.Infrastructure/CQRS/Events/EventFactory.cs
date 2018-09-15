
//using AutoMapper;
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

        //public dynamic CreateConcreteEvent(object @event)
        //{
        //    var type = @event.GetType();
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap(type, type);
        //    });
        //    var mapper = config.CreateMapper();
        //    dynamic result = mapper.Map(@event, type, type);
        //    return result;
        //}
    }
}