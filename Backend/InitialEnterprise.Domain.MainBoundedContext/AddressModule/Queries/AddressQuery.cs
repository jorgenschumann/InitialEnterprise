using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries
{
    public class AddressQuery: IQuery
    {
        public Guid PersonId { get; set; }
        public Guid AddressId { get; set; }
    }
}
