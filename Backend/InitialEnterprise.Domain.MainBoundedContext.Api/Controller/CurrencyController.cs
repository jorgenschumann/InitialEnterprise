using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application;
using InitialEnterprise.Infrastructure.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyApplication currencyApplication;
        public CurrencyController(ICurrencyApplication currencyApplication)
        {
            this.currencyApplication = currencyApplication;
        }

        [HttpGet]       
        public async Task<CurrencyDto> Get()
        {
            return new CurrencyDto();
        }

        [HttpGet("{id}")]
        [ValidateModel]
        public async Task<CurrencyDto> Get(Guid id)
        {
          return await this.currencyApplication.Read(id);        
        }

        [HttpPost]
        [ValidateModel]
        public async Task<CurrencyDto> Post([FromBody]CurrencyDto value)
        {
            return await this.currencyApplication.Save(value);
        }

        [HttpPut]
        [ValidateModel]
        public async Task<CurrencyDto> Put([FromBody]CurrencyDto value)
        {
            return new CurrencyDto();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {

        }
    }
}
