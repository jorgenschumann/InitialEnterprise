using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries
{
    public class CustomerQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
