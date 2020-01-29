using AgileObjects.AgileMapper;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using System.Security.Claims;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public class UserAccountApplication : IUserAccountApplication
    {
        private readonly IDispatcher dispatcher;
       
        public UserAccountApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }    

        public async Task<ApplicationUser> Query(Guid id)
        {
            var query = new UserQuery { Id = id };
            return await dispatcher.Query<UserQuery, ApplicationUser>(query);
        }
        public async Task<List<ClaimDto>> QueryClaims(Guid id)
        {
            var query = new UserQuery { Id = id };
            var claims = await dispatcher.Query<UserQuery, IList<Claim>>(query);
            return Mapper.Map(claims ).ToANew<List<ClaimDto>>();
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