using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface IAddressApplication
    {
        Task<PersonAddressDto> Query(Guid personId, Guid addressId);

        Task<ICommandHandlerAggregateAnswer> Create(Guid personId, PersonAddressDto dto);

        Task<ICommandHandlerAggregateAnswer> Update(Guid personId, PersonAddressDto dto);

        Task<ICommandHandlerAggregateAnswer> Delete(Guid personId, Guid id);
    }
}
