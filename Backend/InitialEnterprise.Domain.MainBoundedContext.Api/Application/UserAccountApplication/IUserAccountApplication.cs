using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Shared.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public interface IUserAccountApplication
    {
        Task<UserSignInResultDto> LogIn(UserLoginDto model);

        Task<UserSignInResult> SignIn(UserLoginDto model);

        Task<IdentityResult> Register(UserRegisterDto model);

        Task<IdentityResult> Update(UserDto model);

        Task<IdentityResult> Delete(Guid id);

        Task<ApplicationUser> Query(Guid id);

        Task<ApplicationUser> UploadImage(Guid id, byte[] image);

        Task<IEnumerable<ApplicationUser>> QueryAsync(IQuery query);
    }
}