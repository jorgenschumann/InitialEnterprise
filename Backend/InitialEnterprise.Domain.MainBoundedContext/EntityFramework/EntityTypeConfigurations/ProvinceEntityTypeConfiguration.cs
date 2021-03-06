﻿using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class ProvinceEntityTypeConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.Name);

            builder.HasKey(o => o.Id);           
        }
    }
}