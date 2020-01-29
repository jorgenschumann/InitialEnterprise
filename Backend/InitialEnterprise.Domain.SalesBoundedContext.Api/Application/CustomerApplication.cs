using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries;
using AgileObjects.AgileMapper;

namespace InitialEnterprise.Domain.SalesBoundedContext.Api.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IDispatcher dispatcher;     

        public CustomerApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;         
        }

        public async Task<ICommandHandlerAggregateAnswer> Insert(CustomerDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Query()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDto> Query(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Query(IQuery model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Query(CustomersSearchQueryDto model)
        {
            var query = Mapper.Map(model).ToANew<CustomerSeachQuery>();
            var result = await dispatcher.Query<CustomerSeachQuery, IEnumerable<Customer>>(query);
            return Mapper.Map(result).ToANew<IEnumerable<CustomerDto>>();
        }

        
        public Task<ICommandHandlerAggregateAnswer> Update(CustomerDto model)
        {
            throw new NotImplementedException();
        }

        //public async Task<ICommandHandlerAggregateAnswer> Insert(PersonDto model)
        //{
        //    var command = Mapper.Map(model).ToANew<PersonCreateCommand>();
        //    return await dispatcher.Send<PersonCreateCommand, Person>(command);
        //}

        //public async Task<PersonDto> Query(Guid id)
        //{
        //    var query = new PersonQuery { Id = id };
        //    var person = await dispatcher.Query<PersonQuery, Person>(query);
        //    return Mapper.Map(person).ToANew<PersonDto>();
        //}

        //public async Task<IEnumerable<PersonDto>> Query(IQuery model)
        //{            
        //    var people = await dispatcher.Query<PersonQuery, IEnumerable<Person>>(model as PersonQuery);
        //    return Mapper.Map(people).ToANew<IEnumerable<PersonDto>>();
        //}

        //public async Task<IEnumerable<PersonDto>> Query()
        //{
        //    var personQuery = new PersonQuery();
        //    var people = await dispatcher.Query<PersonQuery, IEnumerable<Person>>(personQuery);
        //    return Mapper.Map(people).ToANew<IEnumerable<PersonDto>>();
        //}

        //public async Task<ICommandHandlerAggregateAnswer> Update(PersonDto model)
        //{
        //    var command = Mapper.Map(model).ToANew<PersonUpdateCommand>();           
        //    return await dispatcher.Send<PersonUpdateCommand, Person>(command);
        //}
    }
}
