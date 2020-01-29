using InitialEnterprise.Domain.MainBoundedContext.Api.Application.ClaimApplication;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Infrastructure.Api;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Controllers
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