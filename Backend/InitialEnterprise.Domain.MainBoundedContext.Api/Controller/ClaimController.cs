using InitialEnterprise.Domain.MainBoundedContext.Api.Application.ClaimApplication;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    public class ClaimController : BaseController
    {
        private readonly IClaimApplication claimApplication;

        public ClaimController(
            IClaimApplication claimApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.claimApplication = claimApplication;
        }

        [HttpGet]
        [Authorize(Policy = ClaimQuery.PolicyName)]
        public async Task<IActionResult> Get()
        {
            var result = await claimApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }
    }

}