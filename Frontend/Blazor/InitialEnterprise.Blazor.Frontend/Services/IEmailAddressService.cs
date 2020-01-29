using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface IEmailAddressService
    {       
        Task<EmailAddressDto> Get(Guid personId, Guid id);

        Task<CommandHandlerAnswerDto<EmailAddressDto>> Put(EmailAddressDto mail);

        Task<CommandHandlerAnswerDto<EmailAddressDto>> Post(EmailAddressDto mail);

        Task Delete(Guid personId, Guid id);
    } 
}
