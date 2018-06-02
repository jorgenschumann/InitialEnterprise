using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Services
{
    public interface ICurrencyService
    {
        Currency Save(Currency currency);
    }

}
