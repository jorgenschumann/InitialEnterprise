using System;
using System.Collections.Generic;
using System.Text;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext: DbContext, IUnitOfWork
    {
        public DbSet<Currency> Currencies { get; set; }
    }
}
