using InitialEnterprise.Domain.SharedKernel;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand :  ICommand;
    }

    //public class RunEnvironment
    //{
    //    public ICommandHandlerFactory Factory { get; set; }

    //    public void Run<T>(T command)
    //    {
    //        ICommandHandler<T> handler = Factory.Create<T>();

    //        //You can add Your own capabilities here: dependency injection, security, transaction management, logging, profiling, spying, storing commands, etc

    //        handler.Handle(command);

    //        //You can add Your own capabilities here
    //    }
    //}

    //public interface ICommandHandlerFactory
    //{
    //    ICommandHandler<T> Create<T>();

    //    ICommandHandler CreateByName(string name);

    //    void Release(ICommandHandler handler);
    //}
}
