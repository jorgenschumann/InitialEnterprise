using FluentValidation;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Commands;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.CommandHandler
{
    public class CustomerCommandHandler
        : ICommandHandlerWithResultAsync<CustomerCreateCommand>,
          ICommandHandlerWithResultAsync<CustomerUpdateCommand>

    {
        //private readonly ICustomerRepository customerRepository;
        //private readonly IValidator<CustomerCreateCommand> createValidationHandler;
        //private readonly IValidator<CustomerUpdateCommand> updateValidationHandler;

        //public CustomerCommandHandler(
        //    ICustomerRepository customerRepository,
        //    IValidator<CustomerCreateCommand> createValidationHandler,
        //    IValidator<CustomerUpdateCommand> updateValidationHandler)
        //{
        //    this.customerRepository = customerRepository;
        //    this.createValidationHandler = createValidationHandler;
        //    this.updateValidationHandler = updateValidationHandler;        
        //}

        public Task<ICommandHandlerAggregateAnswer> HandleAsync(CustomerCreateCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICommandHandlerAggregateAnswer> HandleAsync(CustomerUpdateCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}