using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public interface IMainDbContext : IUnitOfWork
    {
        DbSet<Currency> Currency { get; set; }
        DbSet<CurrencyRate> CurrencyRate { get; set; }
    }

    public interface IIdentityDbContext : IUnitOfWork
    {
    }
}