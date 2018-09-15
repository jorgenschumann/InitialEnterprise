using InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Queries;
using InitialEnterprise.Infrastructure.Api.Attributes;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    public class UserAccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserAccountApplication userAccountApplication;

        public UserAccountController(IUserAccountApplication userAccountApplication)
        {
            this.userAccountApplication = userAccountApplication;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]              
        public async Task<IActionResult> SignIn([FromBody] SignInDto model)
        {
            var result = await userAccountApplication.SignIn(model);

            return Ok(result);
        }
        
        [HttpPost]        
        public async Task<IActionResult> Query([FromBody]UserQuery query)
        {
            var result =(await userAccountApplication.QueryAsync(query));

            return Ok(result); 
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = ClaimDefinitions.UserWrite)]        
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userAccountApplication.Query(id);

            return Ok(result);
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
        //[Authorize(Policy = ClaimDefinitions.UserWrite)] 
        public async Task<IActionResult> Put([FromBody] UserDto model)
        {
            var result = await userAccountApplication.Update(model);

            return Ok(result);
        }
    }
}