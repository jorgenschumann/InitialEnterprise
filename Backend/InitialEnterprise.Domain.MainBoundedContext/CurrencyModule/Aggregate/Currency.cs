using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Events;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class Currency : AggregateRoot
    {
        public string Name { get; private  set; }

        public string IsoCode { get; private set; }

        public decimal Rate { get; private set; }
        
        public Currency()
        {
        }

        public Currency(CreateCurrencyCommand command)
        {
            if (command.IsValid)
            {
                Name = command.Name;
                IsoCode = command.IsoCode;
                Rate = command.Rate;

                AddEvent(new CurrencyCreated { AggregateRootId = Id, Name = command.Name, UserId = command.UserId });
            }
        }

        public void Update(UpdateCurrencyIsoCodeCommand command)
        {
            if (command.IsValid)
            {
                IsoCode = command.IsoCode;

                AddEvent(new CurrencyIsoCodeUpdated { AggregateRootId = Id, IsoCode = command.IsoCode });
            }
        }

        public void Update(UpdateCurrencyRateCommand command)
        {
            if (command.IsValid)
            {
                Rate = command.Rate;

                AddEvent(new CurrencyRateUpdated { AggregateRootId = Id, Rate = command.Rate });
            }
        }

        public void Update(UpdateCurrencyCommand command)
        {
            if (command.IsValid)
            {
                Rate = command.Rate;

                AddEvent(new CurrencyUpdated() { AggregateRootId = Id, Name = command.Name });
            }
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