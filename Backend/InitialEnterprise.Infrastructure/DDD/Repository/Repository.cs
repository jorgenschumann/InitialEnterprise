using System;
using System.Linq;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;

namespace InitialEnterprise.Infrastructure.DDD.Repository
{
    public class Repository<T> : IRepository<T> where T : IAggregateRoot
    {
        private readonly IEventStore _eventStore;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task SaveAsync(T aggregate)
        {
            foreach (var @event in aggregate.Events)
            {
                await _eventStore.SaveEventAsync<T>(@event);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var events = await _eventStore.GetEventsAsync(id);
            var domainEvents = events as DomainEvent[] ?? events.ToArray();
            if (!domainEvents.Any())
            {
                return default(T);
            }

            var aggregate = Activator.CreateInstance<T>();
            aggregate.ApplyEvents(domainEvents);
            return aggregate;
        }
    }
}