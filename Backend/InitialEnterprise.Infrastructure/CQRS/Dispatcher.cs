using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.CQRS.Events;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandSenderAsync commandSenderAsync;
        private readonly IEventPublisherAsync eventPublisherAsync;
        private readonly IQueryProcessorAsync queryProcessorAsync;

        public Dispatcher(ICommandSenderAsync commandSenderAsync, IEventPublisherAsync eventPublisherAsync,
            IQueryProcessorAsync queryProcessorAsync)
        {
            this.commandSenderAsync = commandSenderAsync;
            this.eventPublisherAsync = eventPublisherAsync;
            this.queryProcessorAsync = queryProcessorAsync;
        }

        public async Task<ICommandHandlerAggregateAnswer> Send<TCommand, TAggregate>(TCommand command)
           where TCommand : IDomainCommand
           where TAggregate : IAggregateRoot
        {
            return await commandSenderAsync.Send<TCommand, TAggregate>(command);
        }   

        public async Task Send<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await commandSenderAsync.Send(command);
        }

        public async Task SendAndPublish<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await commandSenderAsync.SendAndPublish(command);
        }

        public async Task SendAndPublish<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            await commandSenderAsync.SendAndPublish<TCommand, TAggregate>(command);
        }

        public async Task<TResult> SendR<TCommand, TResult>(TCommand command)
         where TCommand : IDomainCommand
         where TResult : class
        {
            return await commandSenderAsync.SendAndReturn<TCommand, TResult>(command);
        }

        public async Task Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            await eventPublisherAsync.PublishAsync(@event);
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            return await queryProcessorAsync.ProcessAsync<TQuery, TResult>(query);
        }

    }
}