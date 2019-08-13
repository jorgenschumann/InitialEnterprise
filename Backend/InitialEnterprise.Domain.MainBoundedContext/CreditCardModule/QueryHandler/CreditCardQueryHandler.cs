using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.QueryHandler
{
    public class CreditCardQueryHandler :
      IQueryHandlerAsync<PersonCreditCardQuery, CreditCard>,
      IQueryHandlerAsync<CreditCardQuery, CreditCard>
    {
        private readonly ICreditCardRepository creditCardRepository;
        public CreditCardQueryHandler(ICreditCardRepository creditCardRepository)
        {
            this.creditCardRepository = creditCardRepository;
        }

        public async Task<CreditCard> Retrieve(PersonCreditCardQuery query)
        {
            return await creditCardRepository.Query(query);
        }

        public async Task<CreditCard> Retrieve(CreditCardQuery query)
        {
            return await creditCardRepository.Query(query);
        }
    }


}
