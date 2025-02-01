using Category.Infrastructure;
using Category.Infrastructure.Repositories;
using Category.Service.CatalogBrands;

namespace TestTools.Brands
{
    public static class BrandFactory
    {
        public static CatalogBrandAppService CreateService(CatalogDbContext dbContext)
        {
            var unitOfWork = new EFUnitOfWork(dbContext);
            var catalogRepository = new EFCatalogBrandRepository(dbContext);

            return new CatalogBrandAppService(unitOfWork, catalogRepository);
        }
    }
}
