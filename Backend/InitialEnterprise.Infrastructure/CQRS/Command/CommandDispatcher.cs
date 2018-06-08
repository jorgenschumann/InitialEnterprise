using System;
using InitialEnterprise.Domain.SharedKernel;
using SimpleInjector;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private CommandEnvironment commandEnvironment;
        public CommandDispatcher(CommandEnvironment commandEnvironment)
        {
            this.commandEnvironment = commandEnvironment;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {          
            commandEnvironment.Run(command);
        }      
    }
    
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();     
    }
}
