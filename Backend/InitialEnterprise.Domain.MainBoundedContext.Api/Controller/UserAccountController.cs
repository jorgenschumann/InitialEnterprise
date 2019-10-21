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
using InitialEnterprise.Shared.Dtos;

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
        [Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto model)
        {
            var result = await userAccountApplication.SignIn(model);
            return result.SignInResult.Succeeded ? (IActionResult)Ok(result) : Unauthorized();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] UserLoginDto model)
        {
            var result = await userAccountApplication.LogIn(model);
            return result.Success ? (IActionResult)Ok(result) : Unauthorized();
        }

        [HttpPost]
        [Authorize(Policy = UserReadClaim.PolicyName)]
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

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserRegisterDto model)
        {
            var result = await userAccountApplication.Register(model);
            return Ok(result);
        }            

        [HttpPut("{id}")]
        [Authorize(Policy = UserWriteClaim.PolicyName)]
        public async Task<IActionResult> Put(Guid id, [FromBody]UserDto model)
        {
            var result = await userAccountApplication.Update(model);
            return Ok(result);
        }

        [HttpPost("uploadimage/{id}"), DisableRequestSizeLimit]
        [AllowAnonymous]//[Authorize(Policy = UserWriteClaim.PolicyName)]
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