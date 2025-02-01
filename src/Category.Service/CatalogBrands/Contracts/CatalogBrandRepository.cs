using Category.Domain;
using Category.Domain.CommanInterfaces;

namespace Category.Service.CatalogBrands.Contracts
{
    public interface CatalogBrandRepository : IRepository
    {
        void Add(CatalogBrand brand);
        Task<bool> IsExist(string brand);
    }
}
