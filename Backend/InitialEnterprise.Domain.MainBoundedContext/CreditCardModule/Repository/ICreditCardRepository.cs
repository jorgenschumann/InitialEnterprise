using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository
{
    public interface ICreditCardRepository //: IRepository<PersonAddress>
    {
        Task<CreditCard> Query(PersonCreditCardQuery query);

        Task<CreditCard> Query(CreditCardQuery query);
    }
}
