using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Events;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandHandlerWithEventsAsync<in TCommand> where TCommand : ICommand
    {
        Task<IEnumerable<IEvent>> HandleAsync(TCommand command);
    }
}