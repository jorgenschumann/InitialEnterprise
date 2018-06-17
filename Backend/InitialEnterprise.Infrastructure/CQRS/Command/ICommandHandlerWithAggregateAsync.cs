using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Infrastructure.CQRS.Command
{
    public interface ICommandHandlerWithAggregateAsync<in TCommand> where TCommand : IDomainCommand
    {
        Task<IAggregateRoot> HandleAsync(TCommand command);
    }
}
