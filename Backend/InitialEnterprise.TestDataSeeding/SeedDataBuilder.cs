using System.Collections.Generic;
using System.Linq;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.DDD.Event;
using SeedPacket.Extensions;

namespace InitialEnterpriseTests.DataSeeding
{
    public class SeedDataBuilder
    {
        public static IEnumerable<TEntity> BuildEntities<TEntity>(int count)
        {
            return new List<TEntity>().Seed(count);
        }

        public static List<Currency> BuildCurrencies(int count = 100)
        {
            var currencies = BuildEntities<Currency>(count).ToList();

            foreach (var currency in currencies)
            {
                var events = BuildEntities<DomainEvent>(10).ToList();

                foreach (var @event in events)
                {
                    @event.AggregateRootId = currency.Id;
                }
                currency.ApplyEvents(events);
            }

            return currencies;
        }
    }
}