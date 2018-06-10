using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application;
using InitialEnterprise.Infrastructure.Api.Filter;
using InitialEnterprise.Infrastructure.Application;
using Microsoft.AspNetCore.Mvc;

namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    [Route("api/[controller]")]    public class CurrencyController : Controller
    {

        private readonly ICurrencyApplication currencyApplication;
        public CurrencyController(ICurrencyApplication currencyApplication)
        {
            this.currencyApplication = currencyApplication;
        }

        [HttpGet]
        [AddHeaderWithFactory]      
        public IEnumerable<string> Get()
        {
            var retval = new string[] { "value1", "value2" };
                       

            return retval;
        }

        [HttpGet("{id}")]
        [ValidateModel] [AddHeaderWithFactory]
        public async Task<CurrencyDto> Get(Guid id)
        {
          return await this.currencyApplication.Read(id);        
        }

        [HttpPost]
        [ValidateModel]
        public void Post([FromBody]BaseDataTransferObject value)
        {
            var foo = value;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
