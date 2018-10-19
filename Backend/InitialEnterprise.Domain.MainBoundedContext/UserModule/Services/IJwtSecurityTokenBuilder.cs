using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using System;

namespace InitialEnterprise.Infrastructure.Api.Auth
{
    public interface IJwtSecurityTokenBuilder
    {
        string CreateToken(ApplicationUser user);
    }
}