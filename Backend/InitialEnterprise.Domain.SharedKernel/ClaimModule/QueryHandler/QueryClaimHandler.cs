using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Queries;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SharedKernel.ClaimModule.QueryHandler
{
    public class QueryClaimHandler :
          IQueryHandlerAsync<Queries.ClaimQuery, ClaimDefinition>
    {
        public async Task<ClaimDefinition> RetrieveAsync(Queries.ClaimQuery query)
        {
            return null;//return await Task.FromResult(new ClaimsDefinitions().Claims);    
        }
    }
}
