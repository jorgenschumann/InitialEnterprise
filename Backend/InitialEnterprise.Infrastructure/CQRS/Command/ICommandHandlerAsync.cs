using System.Threading.Tasks;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
