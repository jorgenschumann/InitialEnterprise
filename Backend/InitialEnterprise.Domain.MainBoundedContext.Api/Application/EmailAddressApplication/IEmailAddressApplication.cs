using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface IEmailAddressApplication
    {   
        Task<ICommandHandlerAggregateAnswer> Create(Guid personId, EmailAddressDto dto);

        Task<ICommandHandlerAggregateAnswer> Update(Guid personId, EmailAddressDto dto);

        Task<ICommandHandlerAggregateAnswer> Delete(Guid personId, Guid id);
    }
}
