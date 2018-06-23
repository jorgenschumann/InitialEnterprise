using System;
using InitialEnterprise.Infrastructure.CQRS.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries
{
    public class CurrencyQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}