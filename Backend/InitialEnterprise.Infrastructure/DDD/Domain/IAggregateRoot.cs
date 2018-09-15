using System;
using System.Collections.Generic;
using FluentValidation.Results;
using InitialEnterprise.Infrastructure.DDD.Event;
using Newtonsoft.Json;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{   
    public interface IAggregateRoot
    {
        Guid Id { get; }

        Guid UserId { get; }
        
        [JsonIgnore]
        IList<IDomainEvent> Events { get; }

        void ApplyEvents(IEnumerable<IDomainEvent> events);
    }

    public interface ICommandHandlerAnswer
    {
        [JsonConverter(typeof(ConcreteConverter<AggregateRoot>))]
        IAggregateRoot AggregateRoot { get; set; }
        ValidationResult ValidationResult { get; set; }
    }

    public class CommandHandlerAnswer : ICommandHandlerAnswer
    {        
        public IAggregateRoot AggregateRoot { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
   
    public class ConcreteConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

}