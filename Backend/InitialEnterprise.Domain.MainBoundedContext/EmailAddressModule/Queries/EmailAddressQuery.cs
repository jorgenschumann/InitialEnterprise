using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Repository
{
    public class EmailAddressQuery: IQuery
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}