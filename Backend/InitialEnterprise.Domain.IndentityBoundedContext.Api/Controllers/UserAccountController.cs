using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Infrastructure.Misc;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Infrastructure.Api;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{

    [Authorize]
    [Route("api/[controller]")]
    public class UserAccountController : BaseController
    {
        private readonly IUserAccountApplication userAccountApplication;

        public UserAccountController(
            IUserAccountApplication userAccountApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.userAccountApplication = userAccountApplication;
        }

        [HttpPost]
        [Authorize(Policy = UserQueryClaim.PolicyName)]
        public async Task<IActionResult> Query([FromBody]UserQuery query)
        {
            var result = await userAccountApplication.QueryAsync(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = UserQueryClaim.PolicyName)]
        public async Task<IActionResult> Get()
        {
            var result = await userAccountApplication.QueryAsync(new UserQuery());
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = UserReadClaim.PolicyName)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userAccountApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("claims/{id}")]
        [Authorize(Policy = UserReadClaim.PolicyName)]
        public async Task<IActionResult> GetClaims(Guid id)
        {
            var result = await userAccountApplication.QueryClaims(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }        

        [HttpPut("{id}")]
        [Authorize(Policy = UserWriteClaim.PolicyName)]
        public async Task<IActionResult> Put(Guid id, [FromBody]UserDto model)
        {
            var result = await userAccountApplication.Update(model);
            return Ok(result);
        }

        [HttpPost("uploadimage/{id}"), DisableRequestSizeLimit]
        [Authorize(Policy = UserWriteClaim.PolicyName)]
        public async Task<IActionResult> UploadImage(Guid id)
        {
            var result = await userAccountApplication.UploadImage(id, Request.Form.Files[0].ToByteArray());
            return result.IsNotNull() ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = UserDeleteClaim.PolicyName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await userAccountApplication.Delete(id);
            return Ok(result);
        }
    }
}