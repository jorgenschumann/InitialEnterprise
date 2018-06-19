using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Handler
{
    public class CreateCurrencyCommandHandler : ICommandHandlerWithAggregateAsync<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository currencyRepository;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<IAggregateRoot> HandleAsync(CreateCurrencyCommand command)
        {
            return await this.currencyRepository.Add(new Currency(command));
        }
    }
}
