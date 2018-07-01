using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.DDD.Command
{
    public interface ICommandStore
    {
        Task SaveCommandAsync<TAggregate>(IDomainCommand command) where TAggregate : IAggregateRoot;

        Task<IEnumerable<DomainCommand>> GetCommandsAsync(Guid aggregateId);
    }

    public class CommandStore : ICommandStore
    {
        public async Task SaveCommandAsync<TAggregate>(IDomainCommand command) where TAggregate : IAggregateRoot
        {
            await Task.CompletedTask;
            // throw new NotImplementedException();
        }

        public async Task<IEnumerable<DomainCommand>> GetCommandsAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}