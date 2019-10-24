using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> Get();

        Task<PersonDto> Get(Guid id);

        Task<CommandHandlerAnswerDto<PersonDto>> Put(PersonDto person);

        Task<CommandHandlerAnswerDto<PersonDto>> Post(PersonDto person);

        Task Delete(Guid id);
    }

}
