using Category.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.EntitiesMap
{
    public class CatalogItemEntityMap : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable(CatalogItem.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Slug)
                   .HasMaxLength(150);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(5000);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(15,2)");

            builder.Property(x => x.MaxStockThreshold)
                   .IsRequired();

            builder.Property(x => x.AvailableStock)
                   .IsRequired();

            builder.HasMany(x => x.Medias)
                   .WithOne(z => z.CatalogItem)
                   .HasForeignKey(_ => _.CatalogItemId);
        }
    }
}
