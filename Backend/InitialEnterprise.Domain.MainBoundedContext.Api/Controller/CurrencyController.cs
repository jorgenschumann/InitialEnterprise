using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency;
using InitialEnterprise.Infrastructure.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Route("api/[controller]")]
    public class CurrencyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICurrencyApplication currencyApplication;
        public CurrencyController(ICurrencyApplication currencyApplication)
        {
            this.currencyApplication = currencyApplication;
        }

        [HttpGet("{id}")]
        [ValidateModel]
        public async Task<CurrencyDto> Get(Guid id)
        {
          return await this.currencyApplication.Read(id);        
        }

        [HttpPost]
        [ValidateModel]
        public async Task Post([FromBody]CurrencyDto value)
        {
             await this.currencyApplication.Save(value);
        }
    }
}
