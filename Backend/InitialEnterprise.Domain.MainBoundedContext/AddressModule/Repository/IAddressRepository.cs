using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository
{
    public interface IAddressRepository //: IRepository<PersonAddress>
    {
        Task<PersonAddress> Query(AddressQuery query);
    }
}
