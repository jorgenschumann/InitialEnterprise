﻿using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public interface ICurrencyRepository :  IRepository<Currency>
    {      
        Currency Add(Currency currency);

        Currency Update(Currency currency);

        Task<Currency> ReadAsync(Guid currencyId);        

    }
}
