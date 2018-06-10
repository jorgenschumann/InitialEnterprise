using System;
using System.Linq;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public class CurrencyRepository : ICurrencyRepository, IInjectableRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IMainDbContext MainDbContext { get { return unitOfWork as IMainDbContext; } }

        public CurrencyRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Currency Add(Currency currency)
        {
            throw new NotImplementedException();
        }

        public async Task<Currency> ReadAsync(Guid currencyId)
        {
            return await MainDbContext.Currencies.FindAsync(currencyId);          
        }
               
        public Currency Update(Currency currency)
        {
            throw new NotImplementedException();
        }

    }
}
