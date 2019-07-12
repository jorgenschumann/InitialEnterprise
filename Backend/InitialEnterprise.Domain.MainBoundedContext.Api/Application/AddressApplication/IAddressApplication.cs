using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface IAddressApplication
    {
        Task<PersonAddressDto> Query(Guid personId, Guid addressId);

        Task<ICommandHandlerAnswer> Create(Guid personId, PersonAddressDto dto);

        Task<ICommandHandlerAnswer> Update(Guid personId, PersonAddressDto dto);

        Task<ICommandHandlerAnswer> Delete(Guid personId, Guid id);
    }
}
