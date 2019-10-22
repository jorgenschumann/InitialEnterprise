using FluentValidation.Results;
using Newtonsoft.Json;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public interface ICommandHandlerEntityAnswer
    {
        [JsonConverter(typeof(ConcreteConverter<Entity>))]
        IEntity Entity { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}