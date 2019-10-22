using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CountryModule.Queries
{
    public class CountryQuery : IQuery
    {
        public Guid CountryId { get; set; }
    }
}
