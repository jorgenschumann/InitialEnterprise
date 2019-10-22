using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository
{
    public interface IAddressRepository //: IRepository<PersonAddress>
    {
        Task<PersonAddress> Query(AddressQuery query);
    }

    public class AddressRepository : IAddressRepository
    {
        private readonly IMainDbContext mainDbContext;

        public AddressRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;
           
        public async Task<PersonAddress> Query(AddressQuery query)
        {
            var personAddress = await mainDbContext
                .PersonAddress        
                .FirstOrDefaultAsync(p => p.PersonId == query.PersonId && p.Id == query.AddressId);
            return personAddress;
        }
    }
}
