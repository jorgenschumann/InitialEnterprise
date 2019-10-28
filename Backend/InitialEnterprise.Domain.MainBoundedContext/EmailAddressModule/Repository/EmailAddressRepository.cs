using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Repository
{
    public class EmailAddressRepository : IEmailAddressRepository
    {
        private readonly IMainDbContext mainDbContext;

        public EmailAddressRepository(MainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public async Task<EmailAddress> Query(EmailAddressQuery query)
        {
            var personAddress = await mainDbContext
                .EmailAddress
                .FirstOrDefaultAsync(p => p.PersonId == query.PersonId && p.Id == query.Id);
            return personAddress;
        }
    }
}
