using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public interface IUserAccountApplication
    {
        Task<UserSignInResult> SignIn(UserLoginDto model);

        Task<IdentityResult> Register(UserRegisterDto model);

        Task<IdentityResult> Update(UserDto model);

        Task<IdentityResult> Delete(Guid id);

        Task<ApplicationUser> Query(Guid id);

        Task<ApplicationUser> UploadImage(Guid id, byte[] image);

        Task<IEnumerable<ApplicationUser>> QueryAsync(IQuery query);
    }

    public class UserAccountApplication : IUserAccountApplication
    {
        private readonly IDispatcher dispatcher;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserAccountApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<UserSignInResult> SignIn(UserLoginDto model)
        {
            var command = Mapper.Map(model).ToANew<SignInCommand>();
            return await dispatcher.SendAndReturnAsync<SignInCommand, UserSignInResult>(command);
        }

        public async Task<IdentityResult> Register(UserRegisterDto model)
        {
            var command = Mapper.Map(model).ToANew<UserRegisterCommand>();
            return await dispatcher.SendAndReturnAsync<UserRegisterCommand, IdentityResult>(command);
        }

        public async Task<ApplicationUser> Query(Guid id)
        {
            var query = new UserQuery { Id = id };
            return await dispatcher.GetResultAsync<UserQuery, ApplicationUser>(query);
        }

        public async Task<IdentityResult> Update(UserDto model)
        {
            var command = Mapper.Map(model).ToANew<UserUpdateCommand>();
            return await dispatcher.SendAndReturnAsync<UserUpdateCommand, IdentityResult>(command);
        }

        public async Task<IEnumerable<ApplicationUser>> QueryAsync(IQuery query)
        {
            var userQuery = query as UserQuery;
            return await dispatcher.GetResultAsync<UserQuery, IEnumerable<ApplicationUser>>(userQuery);
        }

        public Task<IdentityResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> UploadImage(Guid id, byte[] image)
        {
            var command = new UserUpdateImageCommand
            {
                Id = id,
                Image = image
            };
            return await dispatcher.SendAndReturnAsync<UserUpdateImageCommand, ApplicationUser>(command);
        }
    }
}