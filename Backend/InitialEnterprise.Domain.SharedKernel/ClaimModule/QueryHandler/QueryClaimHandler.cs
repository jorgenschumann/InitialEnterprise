using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SharedKernel.ClaimModule.QueryHandler
{
    public class QueryClaimHandler :
        IQueryHandlerAsync<Queries.ClaimQuery, List<IClaimDefinition>>
    {
        public async Task<List<IClaimDefinition>> Retrieve(Queries.ClaimQuery query)
        {          
            return new List<IClaimDefinition>
            {
                new CurrencyCreateClaim(),
                new CurrencyDeleteClaim(),
                new CurrencyQueryClaim(),
                new CurrencyReadClaim(),
                new CurrencyWriteClaim(),

                new PersonCreateClaim(),
                new PersonDeleteClaim(),
                new PersonQueryClaim(),
                new PersonReadClaim(),
                new PersonWriteClaim(),

                new UserReadClaim(),
                new UserDeleteClaim(),
                new UserQueryClaim(),
                new UserReadClaim(),
                new UserWriteClaim(),

                new CountryReadClaim(),
                new CountryDeleteClaim(),
                new CountryQueryClaim(),
                new CountryReadClaim(),
                new CountryWriteClaim()
            };
        }
    }
}
