using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.Application;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public interface ICurrencyApplication
    {
        Task<CurrencyDto> Query(Guid id);

        Task Insert(CurrencyDto currencyDto);
    }

    public class CurrencyDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Rate { get; set; }

        public IEnumerable<DomainEventDto> Events { get; set; }
    }

    public class DomainEventDto 
    {
        public Guid Id { get; set; } 
        public Guid AggregateRootId { get; set; }
        public Guid CommandId { get; set; }
        public Int64 Version { get; set; }
        public Guid UserId { get; set; }
        public String Source { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}