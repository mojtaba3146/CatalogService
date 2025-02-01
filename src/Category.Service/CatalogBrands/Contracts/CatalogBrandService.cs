using Category.Domain.CommanInterfaces;
using Category.Service.CatalogBrands.Contracts.Dtos;

namespace Category.Service.CatalogBrands.Contracts
{
    public interface CatalogBrandService : IService
    {
        Task<int> Create(CreateCatalogBrandDto dto);
    }
}
