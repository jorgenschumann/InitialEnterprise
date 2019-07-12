using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface IEmailAddressApplication
    {   
        Task<ICommandHandlerAnswer> Create(Guid personId, EmailAddressDto dto);

        Task<ICommandHandlerAnswer> Update(Guid personId, EmailAddressDto dto);

        Task<ICommandHandlerAnswer> Delete(Guid personId, Guid id);
    }
}
