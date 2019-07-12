using System;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly ICountryApplication countryApplication;

        public CountryController(
            ICountryApplication countryApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.countryApplication = countryApplication;
        }          

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await countryApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await countryApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }       
    }
}

