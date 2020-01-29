using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.ClaimApplication
{
    public interface IClaimApplication
    {
        Task<IEnumerable<ClaimDto>> Query();

        Task<IEnumerable<ClaimDto>> Query(IQuery model);
    }
}
