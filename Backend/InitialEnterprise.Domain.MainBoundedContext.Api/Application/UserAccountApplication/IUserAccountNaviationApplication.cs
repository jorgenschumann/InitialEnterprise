using System;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public interface IUserAccountNaviationApplication
    {
        Task<UserNavigationDto> Query(Guid userId);
    }
}