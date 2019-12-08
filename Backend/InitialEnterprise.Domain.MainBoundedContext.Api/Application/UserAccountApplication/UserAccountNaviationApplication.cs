using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public class UserAccountNaviationApplication : IUserAccountNaviationApplication
    {
        private readonly IDispatcher dispatcher;
        public UserAccountNaviationApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public async Task<UserNavigationDto> Query(Guid userId)
        {
            var query = new UserQuery { Id = userId };
            var result = await dispatcher.Query<UserQuery, UserNavigation>(query);
            return Mapper.Map(result).ToANew<UserNavigationDto>();
        }
    }
}