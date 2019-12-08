using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Get();

        Task<UserDto> Get(Guid id);

        Task<List<ClaimDto>> GetClaims(Guid id);

        Task<CommandHandlerAnswerDto<UserDto>> Put(UserDto user);

        Task<CommandHandlerAnswerDto<UserDto>> Post(UserDto user);     

        Task Delete(Guid id);
    }

}
