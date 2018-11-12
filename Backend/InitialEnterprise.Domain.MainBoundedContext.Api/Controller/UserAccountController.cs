using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserAccountController : BaseController
    {
        private readonly IUserAccountApplication userAccountApplication;
        readonly IOptions<JwtAuthentication> jwtAuthentication;

        public UserAccountController(
            IOptions<JwtAuthentication> jwtAuthentication,
            IUserAccountApplication userAccountApplication, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {       
            this.userAccountApplication = userAccountApplication;
            this.jwtAuthentication = jwtAuthentication;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]              
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto model)
        { 
            var result = await userAccountApplication.SignIn(model) as UserSignInResult;
            return result.SignInResult.Succeeded ? (IActionResult)Ok(result) : Unauthorized();
        }
        
        [HttpPost]
        //[Authorize(Policy = ClaimDefinitions.CurrencyQuery)]  
        public async Task<IActionResult> Query([FromBody]UserQuery query)
        {
            var result =await userAccountApplication.QueryAsync(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = ClaimDefinitions.UserWrite)]        
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userAccountApplication.Query(id);
             return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("register")]
        //[AllowAnonymous]             
        public async Task<IActionResult> Post([FromBody] UserRegisterDto model)
        {
            var result = await userAccountApplication.Register(model);   
            return Ok(result);
        }


        [HttpPut]
        //[Authorize(Policy = ClaimDefinitions.UserWrite)]   
        public async Task<IActionResult> Put([FromBody] UserDto model)
        {
            var result = await userAccountApplication.Update(model);
            return Ok(result);
        }
    }
}