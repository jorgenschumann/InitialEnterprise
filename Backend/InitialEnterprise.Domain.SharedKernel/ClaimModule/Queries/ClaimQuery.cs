using InitialEnterprise.Infrastructure.CQRS.Queries;

namespace InitialEnterprise.Domain.SharedKernel.ClaimModule.Queries
{
    public class ClaimQuery : IQuery
    {
        public string Module { get; set; }
    }
}
