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
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{

    public class UserAccountApplication : IUserAccountApplication
    {
        private readonly IDispatcher dispatcher;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserAccountApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<UserSignInResultDto> LogIn(UserLoginDto model)
        {
            var command = Mapper.Map(model).ToANew<SignInCommand>();
            var result = await dispatcher.SendR<SignInCommand, UserSignInResult>(command);                  
            
            return Mapper.Map(result).ToANew<UserSignInResultDto>();
        }            

        public async Task<UserSignInResult> SignIn(UserLoginDto model)
        {
            var command = Mapper.Map(model).ToANew<SignInCommand>();
            return await dispatcher.SendR<SignInCommand, UserSignInResult>(command);
        }

        public async Task<IdentityResult> Register(UserRegisterDto model)
        {
            var command = Mapper.Map(model).ToANew<UserRegisterCommand>();
            return await dispatcher.SendR<UserRegisterCommand, IdentityResult>(command);       
        }

        public async Task<ApplicationUser> Query(Guid id)
        {
            var query = new UserQuery { Id = id };
            return await dispatcher.Query<UserQuery, ApplicationUser>(query);
        }

        public async Task<IdentityResult> Update(UserDto model)
        {
            var command = Mapper.Map(model).ToANew<UserUpdateCommand>();
            return await dispatcher.SendR<UserUpdateCommand, IdentityResult>(command);
        }

        public async Task<IEnumerable<ApplicationUser>> QueryAsync(IQuery query)
        {
            var userQuery = query as UserQuery;
            return await dispatcher.Query<UserQuery, IEnumerable<ApplicationUser>>(userQuery);
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
            return await dispatcher.SendR<UserUpdateImageCommand, ApplicationUser>(command);
        }
    }
}