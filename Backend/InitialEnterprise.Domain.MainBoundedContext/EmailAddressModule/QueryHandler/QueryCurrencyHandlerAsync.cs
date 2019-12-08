using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.QueryHandler
{
    public class QueryEmailAddressHandlerAsync :
        IQueryHandlerAsync<EmailAddressQuery, EmailAddress>
    {
        private readonly IEmailAddressRepository emailAddressRepository;

        public QueryEmailAddressHandlerAsync(IEmailAddressRepository emailAddressRepository)
        {
            this.emailAddressRepository = emailAddressRepository;
        }

        public async Task<EmailAddress> Retrieve(EmailAddressQuery query)
        {
            return await emailAddressRepository.Query(query);
        }
    }
}