using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandSenderAsync
    {
        Task Send<TCommand>(TCommand command) 
            where TCommand : ICommand;

        Task<ICommandHandlerAggregateAnswer> Send<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand 
            where TAggregate : IAggregateRoot;   

        Task<TResult> SendAndReturn<TCommand, TResult>(TCommand command)
           where TCommand : IDomainCommand
           where TResult : class;

        Task SendAndPublish<TCommand>(TCommand command) 
            where TCommand : ICommand;

        Task SendAndPublish<TCommand, TAggregate>(TCommand command) 
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot;
    }
}