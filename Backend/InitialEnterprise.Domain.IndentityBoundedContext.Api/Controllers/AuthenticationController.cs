using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Infrastructure.Api;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using Microsoft.AspNetCore.Cors;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationApplication authenticationApplication;

        public AuthenticationController(
            IAuthenticationApplication authenticationApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.authenticationApplication = authenticationApplication;
        }        

        [HttpPost]
        [Route("signin")]       
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto model)
        {
            var result = await authenticationApplication.SignIn(model);
            return result.SignInResult.Succeeded ? (IActionResult)Ok(result) : Unauthorized();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] UserLoginDto model)
        {
            var result = await authenticationApplication.LogIn(model);
            return result.Success ? (IActionResult)Ok(result) : Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserRegisterDto model)
        {
            var result = await authenticationApplication.Register(model);
            return Ok(result);
        }
    }
}