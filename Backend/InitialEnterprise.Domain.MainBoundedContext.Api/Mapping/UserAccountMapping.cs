using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.MappingProfiles
{   
    public class UserAccountConfiguration 
    {
        public UserAccountConfiguration()
        {
            Mapper.WhenMapping
             .From<UserSignInResult>()
             .To<UserSignInResultDto>()
             .Map((p, dto) => p.SignInResult.Succeeded)
             .To(p => p.Success);
        }
    } 
}
