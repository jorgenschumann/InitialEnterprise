using FluentValidation.Results;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public class CommandHandlerAggregateAnswer : ICommandHandlerAggregateAnswer
    {        
        public IAggregateRoot AggregateRoot { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}