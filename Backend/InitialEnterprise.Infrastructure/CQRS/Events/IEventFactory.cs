namespace InitialEnterprise.Infrastructure.CQRS.Events
{
    public interface IEventFactory
    {
        dynamic CreateConcreteEvent(object @event);
    }
}