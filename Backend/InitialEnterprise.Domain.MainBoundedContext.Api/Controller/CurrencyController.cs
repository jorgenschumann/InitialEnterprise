using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.CQRS.Queries;
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
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyApplication currencyApplication;

        public CurrencyController(
            ICurrencyApplication currencyApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.currencyApplication = currencyApplication;
        }

        [HttpPost("query")]
        [Authorize(Policy = CurrencyQueryClaim.PolicyName)]
        public async Task<IActionResult> Query([FromBody]IQuery query)
        {
            var result = await currencyApplication.Query(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = CurrencyReadClaim.PolicyName)]
        [Authorize(Policy = CurrencyQueryClaim.PolicyName)]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await currencyApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = CurrencyReadClaim.PolicyName)]    
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await currencyApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize(Policy = CurrencyCreateClaim.PolicyName)]     
        public async Task<IActionResult> Post([FromBody] CurrencyDto value)
        {
            var result = await currencyApplication.Insert(value);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = CurrencyWriteClaim.PolicyName)]      
     
        public async Task<IActionResult> Put(Guid id, [FromBody] CurrencyDto value)
        {
            var result = await currencyApplication.Update(value);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}