using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Infrastructure.Application;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application
{

    public interface ICurrencyApplication
    {
        Task<CurrencyDto> Read(Guid currencyId);
    }

    public class CurrencyApplication : ICurrencyApplication,IInjectableApplicationService
    {
        private readonly ICurrencyService currencyService;
        public CurrencyApplication(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public async Task<CurrencyDto> Read(Guid currencyId)
        {
            var currency = await this.currencyService.Read(currencyId);
            
            return new CurrencyDto { Id = currency.Id, IsoCode = currency.IsoCode, Name = currency.Name, Rate = currency.Rate.ToString() };
        }
    }

    public class CurrencyDto: BaseDataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get;  set; }

        public string IsoCode { get;  set; }

        public string Rate { get;  set; }

    }

}
