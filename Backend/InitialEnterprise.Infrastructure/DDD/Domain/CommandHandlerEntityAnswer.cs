using FluentValidation.Results;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public class CommandHandlerEntityAnswer : ICommandHandlerEntityAnswer
    {
        public IEntity Entity { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }

}