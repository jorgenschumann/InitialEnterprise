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

        public async Task SendAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await commandSenderAsync.SendAsync(command);
        }

        public async Task<ICommandHandlerAnswer> SendAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            return await commandSenderAsync.SendAsync<TCommand, TAggregate>(command);
        }

        public async Task SendAndPublishAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await commandSenderAsync.SendAndPublishAsync(command);
        }

        public async Task SendAndPublishAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            await commandSenderAsync.SendAndPublishAsync<TCommand, TAggregate>(command);
        }

        public async Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            await eventPublisherAsync.PublishAsync(@event);
        }

        public async Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            return await queryProcessorAsync.ProcessAsync<TQuery, TResult>(query);
        }

        public async Task<TResult> SendAndReturnAsync<TCommand, TResult>(TCommand command)
            where TCommand : IDomainCommand
            where TResult : class
        {
            return await commandSenderAsync.SendAndReturnAsync<TCommand, TResult>(command);
        }
    }
}