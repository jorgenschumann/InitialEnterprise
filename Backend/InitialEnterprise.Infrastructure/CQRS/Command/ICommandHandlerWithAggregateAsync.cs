using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandHandlerWithResultAsync<TCommand> where TCommand : IDomainCommand
    {
        Task<ICommandHandlerAnswer> HandleAsync(TCommand command);
    }

    public interface ICommandHandlerWithResultAsync<TCommand,TResult> where TCommand : IDomainCommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}