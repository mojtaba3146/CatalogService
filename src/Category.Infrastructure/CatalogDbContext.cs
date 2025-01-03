using Category.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Category.Infrastructure
{
    public class CatalogDbContext
        (DbContextOptions<CatalogDbContext> dbContextOptions) :
                                         DbContext(dbContextOptions)
    {
        public DbSet<CatalogBrand> CatalogBrands => Set<CatalogBrand>();
        public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();
        public DbSet<CatalogCategory> CatalogCategories => Set<CatalogCategory>();
        public DbSet<CatalogMedia> CatalogMedia {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
