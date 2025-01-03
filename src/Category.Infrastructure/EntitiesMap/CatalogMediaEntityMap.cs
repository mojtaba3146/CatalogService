using Category.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.EntitiesMap
{
    public class CatalogMediaEntityMap : IEntityTypeConfiguration<CatalogMedia>
    {
        public void Configure(EntityTypeBuilder<CatalogMedia> builder)
        {
            builder.ToTable(CatalogMedia.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(1098);
        }
    }
}
