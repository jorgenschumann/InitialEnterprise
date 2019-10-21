using FluentValidation.Results;
using Newtonsoft.Json;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface ICommandHandlerAggregateAnswer
    {
        [JsonConverter(typeof(ConcreteConverter<AggregateRoot>))]
        IAggregateRoot AggregateRoot { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}