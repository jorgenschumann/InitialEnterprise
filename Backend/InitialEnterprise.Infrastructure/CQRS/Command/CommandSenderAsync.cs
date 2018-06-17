using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Events;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.IoC;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public class CommandSenderAsync : ICommandSenderAsync, IInjectable
    {
        private readonly IResolver resolver;
        private readonly IEventPublisherAsync eventPublisherAsync;
        private readonly IEventFactory eventFactory;
        private readonly IEventStore eventStore;
        private readonly ICommandStore commandStore;

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
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = resolver.Resolve<ICommandHandlerAsync<TCommand>>();

            if (handler == null)
                throw new ApplicationException($"No handler of type CommandHandlerAsync<TCommand> found for command '{command.GetType().FullName}'");

            await handler.HandleAsync(command);
        }

        public async Task SendAsync<TCommand, TAggregate>(TCommand command) 
            where TCommand : IDomainCommand 
            where TAggregate : IAggregateRoot
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await commandStore.SaveCommandAsync<TAggregate>(command);

            var handler = resolver.Resolve<ICommandHandlerWithAggregateAsync<TCommand>>();

            if (handler == null)
                throw new ApplicationException($"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command '{command.GetType().FullName}'");

            var aggregateRoot = await handler.HandleAsync(command);

            foreach (var @event in aggregateRoot.Events)
            {
                @event.CommandId = command.Id;
                var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                await eventStore.SaveEventAsync<TAggregate>((IDomainEvent)concreteEvent);
            }
        }

        public async Task SendAndPublishAsync<TCommand>(TCommand command) 
            where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = resolver.Resolve<ICommandHandlerWithEventsAsync<TCommand>>();

            if (handler == null)
                throw new ApplicationException($"No handler of type ICommandHandlerWithEventsAsync<TCommand> found for command '{command.GetType().FullName}'");

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
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await commandStore.SaveCommandAsync<TAggregate>(command);

            var handler = resolver.Resolve<ICommandHandlerWithAggregateAsync<TCommand>>();

            if (handler == null)
                throw new ApplicationException($"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command '{command.GetType().FullName}'");

            var aggregateRoot = await handler.HandleAsync(command);

            foreach (var @event in aggregateRoot.Events)
            {
                @event.CommandId = command.Id;
                var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                await eventStore.SaveEventAsync<TAggregate>((IDomainEvent)concreteEvent);
                await eventPublisherAsync.PublishAsync(concreteEvent);
            }
        }
    }
}
