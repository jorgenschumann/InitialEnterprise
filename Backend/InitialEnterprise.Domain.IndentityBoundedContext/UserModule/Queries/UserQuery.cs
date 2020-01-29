using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Queries
{
    public class UserQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
