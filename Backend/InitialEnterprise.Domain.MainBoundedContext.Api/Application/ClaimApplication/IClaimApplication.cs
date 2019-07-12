using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.ClaimApplication
{
    public interface IClaimApplication
    {
        Task<IEnumerable<ClaimRequirementDto>> Query();

        Task<IEnumerable<ClaimRequirementDto>> Query(IQuery model);
    }
}
