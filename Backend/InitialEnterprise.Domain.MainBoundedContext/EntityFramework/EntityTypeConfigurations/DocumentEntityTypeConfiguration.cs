using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    class DocumentEntityTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Extension)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.Length)
                .IsRequired();

            builder.Property(x => x.Data);

            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasKey(x => x.Id);
            builder.Ignore(o => o.UserId);
            builder.Ignore(b => b.Events);
        }
    }
}

