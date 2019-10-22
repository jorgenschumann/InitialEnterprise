using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;
using InitialEnterprise.Infrastructure.Utils;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Events;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate
{
    public class Document: AggregateRoot
    {
        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Extension { get; set; }

        [JsonProperty]
        public int Length { get; set; }

        [JsonProperty]
        public byte[] Data { get; set; }

        [JsonProperty]
        public string ContentType { get; set; }


        [JsonConstructor]
        private Document()
        {
        }

        public Document(DocumentCreateCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);
                base.AddEvent(new DocumentCreated
                {
                    AggregateRootId = Id,
                    CommandJson = JsonConvert.SerializeObject(command),
                    UserId = command.UserId
                });
            }
        }

        public Document Update(DocumentUpdateCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);
                base.AddEvent(new DocumentUpdated
                {
                    AggregateRootId = Id,
                    CommandJson = JsonConvert.SerializeObject(command)
                });
            }
            return this;
        }
    }
}
