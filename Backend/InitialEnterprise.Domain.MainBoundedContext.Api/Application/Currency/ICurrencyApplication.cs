using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.IoC;
using NewLibrary.ForString;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.Currency
{
    public interface ICurrencyApplication
    {
        Task<CurrencyDto> Read(Guid currencyId);

        Task Save(CurrencyDto currencyDto);
    }

    public class CurrencyApplication : ICurrencyApplication, IInjectable
    {
       private readonly ICurrencyService currencyService;
        private readonly IDispatcher dispatcher;

        public CurrencyApplication(ICurrencyService currencyService, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.currencyService = currencyService;
        }

        public async Task Save(CurrencyDto currencyDto)
        {
            var updateCommand = new UpdateCurrencyIsoCodeCommand
            {
                IsoCode = currencyDto.IsoCode
            };

            await dispatcher.SendAsync<UpdateCurrencyIsoCodeCommand, CurrencyModule.Aggregate.Currency>(updateCommand);

            var command = new CreateCurrencyCommand
            {
                Name = currencyDto.Name,
                Rate = currencyDto.Rate.toDecimal(),
                IsoCode = currencyDto.IsoCode
            };

            await dispatcher.SendAsync<CreateCurrencyCommand,CurrencyModule.Aggregate.Currency>(command);

        }

        public async Task<CurrencyDto> Read(Guid currencyId)
        {
            var currency = await this.currencyService.Read(currencyId);
            
            return new CurrencyDto { Id = currency.Id, IsoCode = currency.IsoCode, Name = currency.Name, Rate = currency.Rate.ToString() };
        }
    }

    public class CurrencyDto: DataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get;  set; }

        public string IsoCode { get;  set; }

        public string Rate { get;  set; }
    }

}
