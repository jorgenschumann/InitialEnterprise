using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public interface IMainDbContext : IUnitOfWork
    {
        DbSet<Currency> Currency { get; set; }
        DbSet<CurrencyRate> CurrencyRate { get; set; }        
        DbSet<Document> Document { get; set; }
        DbSet<Person> Person { get; set; }
        DbSet<EmailAddress> EmailAddress { get; set; }
        DbSet<PersonAddress> PersonAddress { get; set; }
        DbSet<CreditCard> CreditCard { get; set; }
        DbSet<Country> Country { get; set; }
        DbSet<Province> Province { get; set; }
        DbSet<UserNavigation> UserNavigation { get; set; }
        DbSet<UserNavigationMenuGroup> UserNavigationMenuGroup { get; set; }
        DbSet<UserNavigationMenuGroupItem> UserNavigationMenuGroupItem { get; set; }               

    }
    

    public interface IIdentityDbContext : IUnitOfWork
    {
    }
}