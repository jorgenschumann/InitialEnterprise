using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Services
{
    public interface IJwtSecurityTokenBuilder
    {
        string CreateToken(ApplicationUser user);
    }
}