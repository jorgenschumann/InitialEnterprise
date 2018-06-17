using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Infrastructure.Application;
using MediatR;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application
{
    public interface ICurrencyApplication
    {
        Task<CurrencyDto> Read(Guid currencyId);

        Task<CurrencyDto> Save(CurrencyDto currencyDto);
    }

    public class CurrencyApplication : ICurrencyApplication,IInjectableApplicationService
    {
        private readonly IMediator mediator;
        private readonly ICurrencyService currencyService;

        public CurrencyApplication(ICurrencyService currencyService,IMediator mediator)
        {
            this.mediator = mediator;
            this.currencyService = currencyService;
        }

        public async Task<CurrencyDto> Save(CurrencyDto currencyDto)
        {    
            return new CurrencyDto();
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
