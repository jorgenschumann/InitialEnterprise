using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandSenderAsync
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        Task SendAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand where TAggregate : IAggregateRoot;

        Task SendAndPublishAsync<TCommand>(TCommand command) where TCommand : ICommand;

        Task SendAndPublishAsync<TCommand, TAggregate>(TCommand command) where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot;
    }
}