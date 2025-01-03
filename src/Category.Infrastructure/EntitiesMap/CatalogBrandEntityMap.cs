using Category.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.EntitiesMap
{
    public class CatalogBrandEntityMap : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable(CatalogBrand.TableName);

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .IsRequired(true)
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Brand)
               .HasMaxLength(100)
               .IsRequired(true);
        }
    }
}
