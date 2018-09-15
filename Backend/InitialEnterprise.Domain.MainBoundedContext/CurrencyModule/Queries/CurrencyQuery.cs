using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Queries
{
    public class CurrencyQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}