﻿using Category.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.EntitiesMap
{
    public class CatalogCategoryEntityMap : IEntityTypeConfiguration<CatalogCategory>
    {
        public void Configure(EntityTypeBuilder<CatalogCategory> builder)
        {
            builder.ToTable(CatalogCategory.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Ignore(x => x.Path);

            builder.Property(x => x.Category)
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.Property(x => x.ParentId)
                   .IsRequired(false);

            builder.HasMany(x => x.Children)
                   .WithOne(z => z.Parent)
                   .HasForeignKey(x => x.ParentId);
        }
    }
}
