using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class Currency : AggregateRoot
    {
        [JsonConstructor]
        private Currency()
        {
        }

        public Currency(CurrencyCreateCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);

                base.AddEvent(new CurrencyCreated
                {
                    AggregateRootId = Id,
                    CommandJson = JsonConvert.SerializeObject(command),
                    UserId = command.UserId
                });
            }
        }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string IsoCode { get; private set; }

        [JsonProperty]
        public virtual ICollection<CurrencyRate> Rates { get; private set; }

        public Currency Update(CurrencyUpdateCommand command)
        {
            if (command.IsValid)
            {
                this.Name = command.Name;
                this.IsoCode = command.IsoCode;
                base.AddEvent(new CurrencyUpdated { AggregateRootId = Id, CommandJson = JsonConvert.SerializeObject(command) });
            }

            return this;
        }

        private void Apply(CurrencyCreated @event)
        {
            Id = @event.AggregateRootId;
        }

        private void Apply(CurrencyIsoCodeUpdated @event)
        {
            Id = @event.AggregateRootId;
        }

        private void Apply(CurrencyRateUpdated @event)
        {
            Id = @event.AggregateRootId;
        }
    }
}