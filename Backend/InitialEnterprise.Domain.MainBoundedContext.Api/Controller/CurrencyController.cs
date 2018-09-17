using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Infrastructure.Api.Attributes;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    public static class ClaimDefinitions
    {
        const string READ = "Read";
        const string WRITE = "Write";

        public const string CurrencyRead = READ;
        public const string CurrencyWrite = WRITE;

        public const string UserRead = READ;
        public const string UserWrite = WRITE;
    }  

    [Authorize]
    [Route("api/[controller]")]
    public class CurrencyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICurrencyApplication currencyApplication;

        public CurrencyController(ICurrencyApplication currencyApplication)
        {
            this.currencyApplication = currencyApplication;
        }

        [HttpPost("query")]
        [Authorize(Policy = ClaimDefinitions.CurrencyRead)]
        public async Task<IEnumerable<CurrencyDto>> Query([FromBody]IQuery query)
        {
            return await currencyApplication.Query(query);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = ClaimDefinitions.CurrencyRead)]    
        public async Task<CurrencyDto> Get(Guid id)
        {
            var currencyDto = await currencyApplication.Query(id);
            return currencyDto;
        }

        [HttpPost]
        [Authorize(Policy = ClaimDefinitions.CurrencyWrite)]
        public async Task<IActionResult> Post([FromBody] CurrencyDto value)
        {
            var result = await currencyApplication.Insert(value);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [Authorize(Policy = ClaimDefinitions.CurrencyWrite)]
        public async Task<IActionResult> Put([FromBody] CurrencyDto value)
        {
            var result = await currencyApplication.Update(value);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }
    }
}