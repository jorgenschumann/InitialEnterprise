using InitialEnterprise.Domain.SalesBoundedContext.Api.Application;
using InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate;
using InitialEnterprise.Infrastructure.Api;
using InitialEnterprise.Infrastructure.Utils;
using InitialEnterprise.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerApplication customerApplication;

        public CustomerController(ICustomerApplication customerApplication, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.customerApplication = customerApplication;
        }

        [HttpGet]
        //[Authorize(Policy = CustomerQueryClaim.PolicyName)]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await customerApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = CustomerReadClaim.PolicyName)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await customerApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost("query")]
        //[Authorize(Policy = CustomerQueryClaim.PolicyName)]
        [AllowAnonymous]
        public async Task<IActionResult> Query([FromBody]CustomersSearchQueryDto query)
        {
            var result = await customerApplication.Query(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }
    }

}
