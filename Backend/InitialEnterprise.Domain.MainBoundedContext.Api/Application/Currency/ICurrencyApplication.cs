﻿using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries;
using InitialEnterprise.Infrastructure.Application;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public interface ICurrencyApplication
    {
        Task<CurrencyDto> Query(Guid id);

        Task Save(CurrencyDto currencyDto);
    }

    public class CurrencyDto: DataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get;  set; }

        public string IsoCode { get;  set; }

        public string Rate { get;  set; }
    }

}
