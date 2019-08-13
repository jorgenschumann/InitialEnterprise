using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.QueryHandler
{
    public class CreditCardTypeQueryHandler :       
         IQueryHandlerAsync<CreditCardTypeQuery, IEnumerable<CreditCardType>>
    {
        public async Task<IEnumerable<CreditCardType>> Retrieve(CreditCardTypeQuery query)
        {
            return CreditCardType.List();
        }
    }
}
