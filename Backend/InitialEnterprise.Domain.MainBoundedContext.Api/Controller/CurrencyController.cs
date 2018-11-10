using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        const string QUERY = "Query";
        const string CREATE = "Create";

        public const string CurrencyRead = READ;
        public const string CurrencyQuery = QUERY;
        public const string CurrencyWrite = WRITE;

        public const string UserRead = READ;
        public const string UserWrite = WRITE;

        public const string PersonRead = READ;      
        public const string PersonWrite = WRITE;
        public const string PersonCreate = CREATE;
    }
    

    [Authorize]
    [Route("api/[controller]")]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyApplication currencyApplication;
   
        public CurrencyController(
            ICurrencyApplication currencyApplication,
            IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.currencyApplication = currencyApplication;   
        }

        [HttpPost("query")]       
        [Authorize(Policy = ClaimDefinitions.CurrencyRead)]
        public async Task<IActionResult> Query([FromBody]IQuery query)
        {
            var result = await currencyApplication.Query(query) ;
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = ClaimDefinitions.CurrencyQuery)]
        public async Task<IActionResult> Get()
        {
            var result = await currencyApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = ClaimDefinitions.CurrencyRead)]    
        public async Task<IActionResult> Get(Guid id)
        {
            var currencyDto = await currencyApplication.Query(id);
            var list = new List<CurrencyDto>();
            list.Add(currencyDto);
            return list.IsNotNull() ? (IActionResult)Ok(list) : NotFound();
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