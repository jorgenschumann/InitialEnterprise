using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class EventStore :   IEventStore, IInjectable
    {
        public IUnitOfWork UnitOfWork => mainDbContext as IUnitOfWork;

        private readonly IMainDbContext mainDbContext;

        public EventStore(IMainDbContext context)
        {
            this.mainDbContext = context;
        }
       
        public async Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
             await Task.Run(() => { });
        }
      
        public async Task<IEnumerable<DomainEvent>> GetEventsAsync(Guid aggregateId)
        {
            return await Task.Run(() => { return new List<DomainEvent>(); });
        }
      
    }
}