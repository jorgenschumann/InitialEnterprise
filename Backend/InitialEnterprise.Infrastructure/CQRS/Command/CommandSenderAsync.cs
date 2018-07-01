using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Events;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.Utils;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public class CommandSenderAsync : ICommandSenderAsync
    {
        private readonly ICommandStore commandStore;
        private readonly IEventFactory eventFactory;
        private readonly IEventPublisherAsync eventPublisherAsync;
        private readonly IEventStore eventStore;
        private readonly IResolver resolver;

        public CommandSenderAsync(
            IResolver resolver,
            IEventPublisherAsync eventPublisherAsync,
            IEventFactory eventFactory,
            IEventStore eventStore,
            ICommandStore commandStore)
        {
            this.resolver = resolver;
            this.eventPublisherAsync = eventPublisherAsync;
            this.eventFactory = eventFactory;
            this.eventStore = eventStore;
            this.commandStore = commandStore;
        }

        public async Task SendAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            var handler = resolver.Resolve<ICommandHandlerAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(handler,
                $"No handler of type CommandHandlerAsync<TCommand> found for command '{command.GetType().FullName}'");

            await handler.HandleAsync(command);
        }

        public async Task SendAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            await commandStore.SaveCommandAsync<TAggregate>(command);

            var handler = resolver.Resolve<ICommandHandlerWithAggregateAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(handler,
                $"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command '{command.GetType().FullName}'");

            var aggregateRoot = await handler.HandleAsync(command);

            foreach (var @event in aggregateRoot.Events)
            {
                @event.CommandId = command.Id;
                var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                await eventStore.SaveEventAsync<TAggregate>((IDomainEvent) concreteEvent);
            }
        }

        public async Task SendAndPublishAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            var handler = resolver.Resolve<ICommandHandlerWithEventsAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(handler,
                $"No handler of type ICommandHandlerWithEventsAsync<TCommand> found for command '{command.GetType().FullName}'");

            var events = await handler.HandleAsync(command);

            foreach (var @event in events)
            {
                var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                await eventPublisherAsync.PublishAsync(concreteEvent);
            }
        }

        public async Task SendAndPublishAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            await commandStore.SaveCommandAsync<TAggregate>(command);

            var handler = resolver.Resolve<ICommandHandlerWithAggregateAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(handler,
                $"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command '{command.GetType().FullName}'");

            var aggregateRoot = await handler.HandleAsync(command);

            foreach (var @event in aggregateRoot.Events)
            {
                @event.CommandId = command.Id;
                var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                await eventStore.SaveEventAsync<TAggregate>((IDomainEvent) concreteEvent);
                await eventPublisherAsync.PublishAsync(concreteEvent);
            }
        }
    }
}