using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;

namespace InitialEnterprise.Infrastructure.Api.Auth
{
    public interface IJwtSecurityTokenBuilder
    {
        string CreateToken(ApplicationUser user);
    }
}