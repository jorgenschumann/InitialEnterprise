using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Misc;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Authorize]
    [Route("api/useraccount/{id}/[controller]")]
    public class UserNavigationController : BaseController
    {
        private readonly IUserAccountNaviationApplication userAccountNaviationApplication;

        public UserNavigationController(
            IUserAccountNaviationApplication  userAccountNaviationApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.userAccountNaviationApplication = userAccountNaviationApplication;
        }   

        [HttpGet]
        [Authorize(Policy = UserReadClaim.PolicyName)]        
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userAccountNaviationApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }
    }
}