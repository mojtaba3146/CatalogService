using Category.Domain;
using Category.Service.CatalogBrands.Contracts;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> IsExist(string brand)
        {
            return await _catalogDbContext.CatalogBrands
                .AnyAsync(b => b.Brand == brand);
        }
    }
}
