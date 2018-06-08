using InitialEnterprise.Domain.SharedKernel;
using SimpleInjector;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public class CommandEnvironment
    {
        public ICommandHandlerFactory Factory { get; set; }

        public void Run<T>(T command)
        {
            ICommandHandler<T> handler = Factory.Create<T>();

            handler.Handle(command);
        }
    }

    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Container container;
        public CommandHandlerFactory(Container container)
        {
            this.container = container;
        }

        public ICommandHandler<T> Create<T>()
        {
            throw new System.NotImplementedException();
        }       
    }
}
