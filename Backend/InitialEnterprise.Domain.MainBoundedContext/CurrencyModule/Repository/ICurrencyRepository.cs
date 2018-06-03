using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Repository
{
    public interface ICurrencyRepository
    {
        Currency Save(Currency currency);
    }
}
