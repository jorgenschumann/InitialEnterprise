using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate
{
    public class CurrencyRate : AggregateRoot
    { 
        [JsonProperty]
        public string CurrencyRateDate { get; private set; }

        [JsonProperty]
        public string EndOfDayRate { get; private set; }

        [JsonProperty]
        public string AverageRate { get; private set; }

        [JsonProperty]
        public string ToCurrencyCode { get; private set; }

        [JsonProperty]
        public string FromCurrencyCode { get; private set; }

        [JsonConstructor]
        private CurrencyRate()
        {
        }
    }
}