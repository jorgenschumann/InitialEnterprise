using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Queries
{
    public class DocumentQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
