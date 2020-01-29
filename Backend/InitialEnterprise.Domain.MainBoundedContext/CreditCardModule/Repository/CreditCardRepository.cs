using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly IMainDbContext mainDbContext;

        public CreditCardRepository(IMainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;
           
        public async Task<CreditCard> Query(PersonCreditCardQuery query)
        {         
            var creditCard = await mainDbContext
                .CreditCard        
                .FirstOrDefaultAsync(p => p.PersonId == query.PersonId && p.Id == query.CreditCardId);
            return creditCard;
        }

        public async Task<CreditCard> Query(CreditCardQuery query)
        {
            var creditCard = await mainDbContext
               .CreditCard
               .FirstOrDefaultAsync(p => p.Id == query.CreditCardId);
            return creditCard;
        }
    }
}
