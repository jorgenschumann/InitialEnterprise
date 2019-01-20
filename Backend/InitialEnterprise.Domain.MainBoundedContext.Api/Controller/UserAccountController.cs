using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            var result = await userAccountApplication.SignIn(model) as UserSignInResult;
            return result.SignInResult.Succeeded ? (IActionResult)Ok(result.SignInResult) : Unauthorized();
        }

        [HttpPost]
        [Authorize(Policy = PersonClaims.PersonRead)]
        public async Task<IActionResult> Query([FromBody]UserQuery query)
        {
            var result = await userAccountApplication.QueryAsync(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = PersonClaims.PersonRead)]
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

        [HttpPut]
        [Authorize(Policy = PersonClaims.PersonWrite)]
        public async Task<IActionResult> Put([FromBody] UserDto model)
        {
            var result = await userAccountApplication.Update(model);
            return Ok(result);
        }
    }
}