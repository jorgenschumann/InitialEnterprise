using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries
{
    public class UserNavigationQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
