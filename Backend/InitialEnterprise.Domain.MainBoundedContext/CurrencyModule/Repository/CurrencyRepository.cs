using System;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.DDD.Annotations;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    [DomainRepository]
    public class CurrencyRepository : ICurrencyRepository
    {
        public Currency Save(Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}
