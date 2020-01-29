using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public interface IUserAccountApplication
    {    

        Task<IdentityResult> Update(UserDto model);

        Task<IdentityResult> Delete(Guid id);

        Task<ApplicationUser> Query(Guid id);

        Task<List<ClaimDto>> QueryClaims(Guid id);

        Task<ApplicationUser> UploadImage(Guid id, byte[] image);

        Task<IEnumerable<ApplicationUser>> QueryAsync(IQuery query);
    }
}