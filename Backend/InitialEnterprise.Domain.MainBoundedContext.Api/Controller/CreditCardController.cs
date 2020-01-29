using System;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication;
using InitialEnterprise.Infrastructure.Api;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : BaseController
    {
        private readonly ICreditCardApplication creditCardApplication;

        public CreditCardController(
            IHttpContextAccessor httpContextAccessor, 
            ICreditCardApplication creditCardApplication) : base(httpContextAccessor)
        {
            this.creditCardApplication = creditCardApplication;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await creditCardApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("CreditCardTypes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCreditCardTypes()
        {
            var result = await creditCardApplication.QueryCreditCardTypes();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }
    }
}