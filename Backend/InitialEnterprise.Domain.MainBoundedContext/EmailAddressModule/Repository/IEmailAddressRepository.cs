using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Repository
{
    public interface IEmailAddressRepository 
    {
        Task<EmailAddress> Query(EmailAddressQuery query);
    }
}
