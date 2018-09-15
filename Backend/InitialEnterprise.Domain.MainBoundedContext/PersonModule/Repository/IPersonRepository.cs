using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Repository
{
    public interface IPersonRepository : IRepository<Currency>
    {
        Task<Person> Update(Person person);

        Task<Person> Insert(Person person);

        Task<Person> Query(Guid personId);
    }
}