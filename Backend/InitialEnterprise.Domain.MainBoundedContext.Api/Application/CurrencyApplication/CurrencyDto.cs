using InitialEnterprise.Infrastructure.Application;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public class CurrencyDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Rate { get; set; }

        public IEnumerable<DomainEventDto> Events { get; set; }
    }
}