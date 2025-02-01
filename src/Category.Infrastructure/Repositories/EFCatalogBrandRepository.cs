using Category.Domain;
using Category.Service.CatalogBrands.Contracts;

namespace Category.Infrastructure.Repositories
{
    public class EFCatalogBrandRepository : CatalogBrandRepository
    {
        private readonly CatalogDbContext _catalogDbContext;

        public EFCatalogBrandRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public void Add(CatalogBrand brand)
        {
            _catalogDbContext.CatalogBrands.Add(brand); 
        }
    }
}
