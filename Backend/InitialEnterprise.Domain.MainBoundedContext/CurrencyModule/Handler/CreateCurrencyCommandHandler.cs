using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using MediatR;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public  class CreateCurrencyCommandHandler : IAsyncRequestHandler<CreateCurrencyCommand, bool>        
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMediator mediator;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository, IMediator mediator)
        {
            this.currencyRepository = currencyRepository;
            this.mediator = mediator;
        }

        public async  Task<bool> Handle(CreateCurrencyCommand message)
        {
            var currency = new Currency(message); //TODO -> Factory

            currencyRepository.Add(currency);

           return await currencyRepository.UnitOfWork.SaveEntitiesAsync();
        }     
    }

    public interface IAsyncRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest message);
    }
}
