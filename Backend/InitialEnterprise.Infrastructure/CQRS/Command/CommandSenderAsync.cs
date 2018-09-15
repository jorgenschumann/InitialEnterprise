using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.CQRS.Events;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.Utils;
using System.Linq;

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

            var commandHandler = resolver.Resolve<ICommandHandlerAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(commandHandler,
                $"No handler of type CommandHandlerAsync<TCommand> found for command '{command.GetType().FullName}'");

            await commandHandler.HandleAsync(command);
        }

        public async Task<ICommandHandlerAnswer> SendAsync<TCommand, TAggregate>(TCommand command)
            where TCommand : IDomainCommand
            where TAggregate : IAggregateRoot
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            await commandStore.SaveCommandAsync<TAggregate>(command);

            var commandHandler = resolver.Resolve<ICommandHandlerWithResultAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(commandHandler,
                $"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command '{command.GetType().FullName}'");

            var commandHanderAnswer = await commandHandler.HandleAsync(command);    
            
            if (commandHanderAnswer.ValidationResult.IsValid)
            {
                foreach (var @event in commandHanderAnswer.AggregateRoot.Events)
                {
                    @event.CommandId = command.Id;
                    var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                    await eventStore.SaveEventAsync<TAggregate>((IDomainEvent)concreteEvent);
                }
            }
            return commandHanderAnswer;
        }

        public async Task SendAndPublishAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            var commandHandler = resolver.Resolve<ICommandHandlerWithEventsAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(commandHandler,
                $"No handler of type ICommandHandlerWithEventsAsync<TCommand> found for command" +
                $" '{command.GetType().FullName}'");

            var events = await commandHandler.HandleAsync(command);

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

            var commandHandler = resolver.Resolve<ICommandHandlerWithResultAsync<TCommand>>();

            Guard.AgainstNull<ApplicationException>(commandHandler,
                $"No handler of type ICommandHandlerWithAggregateAsync<TCommand> found for command " +
                $"'{command.GetType().FullName}'");

            var commandHanderAnswer = await commandHandler.HandleAsync(command);

            if (commandHanderAnswer.ValidationResult.IsValid)
            {
                foreach (var @event in commandHanderAnswer.AggregateRoot.Events)
                {
                    @event.CommandId = command.Id;
                    var concreteEvent = eventFactory.CreateConcreteEvent(@event);
                    await eventStore.SaveEventAsync<TAggregate>((IDomainEvent)concreteEvent);
                    await eventPublisherAsync.PublishAsync(concreteEvent);
                }
            }         
        }

        public async Task<TResult> SendAndReturnAsync<TCommand, TResult>(TCommand command)
            where TCommand : IDomainCommand
            where TResult : class
        {
            Guard.AgainstNull<ArgumentNullException>(command);

            //await commandStore.SaveCommandAsync<TResult>(command);

            var commandHandler = resolver.Resolve<ICommandHandlerWithResultAsync<TCommand, TResult>>();

            Guard.AgainstNull<ApplicationException>(commandHandler,
                $"No handler of type ICommandHandlerWithResultAsync<TCommand, TResult> found for command '{command.GetType().FullName}'");

            var commandHanderResult = await commandHandler.HandleAsync(command);

            //if (commandHanderAnswer.ValidationResult.IsValid)
            //{
            //    foreach (var @event in commandHanderAnswer.AggregateRoot.Events)
            //    {
            //        @event.CommandId = command.Id;
            //        var concreteEvent = eventFactory.CreateConcreteEvent(@event);
            //        await eventStore.SaveEventAsync<TAggregate>((IDomainEvent)concreteEvent);
            //    }
            //}
            return commandHanderResult;
        }
    }
}