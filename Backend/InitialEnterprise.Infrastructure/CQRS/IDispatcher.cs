using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.CQRS.Events;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS
{
    public interface IDispatcher
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;

        Task<ICommandHandlerAggregateAnswer> Send<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot;       

        Task<TResult> SendR<TCommand, TResult>(TCommand command)
            where TCommand : IDomainCommand
            where TResult : class;

        Task SendAndPublish<TCommand>(TCommand command) where TCommand :
            ICommand;

        Task SendAndPublish<TCommand, TAggregate>(TCommand command) where TCommand :
            IDomainCommand
            where TAggregate : IAggregateRoot;

        Task Publish<TEvent>(TEvent @event) where TEvent :
            IEvent;

        Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery :
            IQuery;
    }
}