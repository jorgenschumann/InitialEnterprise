using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries
{
    public class PersonQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
