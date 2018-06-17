﻿using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Infrastructure.DDD;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services
{
    public class CurrencyService : ICurrencyService , IInjectableDomainService
    {
        private readonly ICurrencyRepository currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }     

        public async Task<Currency> Read(Guid currencyId)
        {
            return await currencyRepository.Read(currencyId);
        }
    }

}
