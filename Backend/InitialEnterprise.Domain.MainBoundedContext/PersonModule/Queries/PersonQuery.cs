using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries
{
    public class PersonQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
