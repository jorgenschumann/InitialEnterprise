using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class Payment: Entity
    {
        [JsonProperty]
        public string PaymentType { get; private set; }

        [JsonProperty]
        public Guid PersonId { get; private set; }

        public virtual Person Person { get; private set; }

        [JsonConstructor]
        public Payment()
        {
        }
    }
}
