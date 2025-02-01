using Category.Domain;
using Category.Domain.CommanInterfaces;
using Category.Service.CatalogBrands.Contracts;
using Category.Service.CatalogBrands.Contracts.Dtos;

namespace Category.Service.CatalogBrands
{
    public class CatalogBrandAppService(UnitOfWork _unitOfWork,
        CatalogBrandRepository _catalogBrandRepository) : CatalogBrandService
    {
        public async Task<int> Create(CreateCatalogBrandDto dto)
        {
            var catalogBrand = CatalogBrand.Create(dto.Brand);

            _catalogBrandRepository.Add(catalogBrand);

            await _unitOfWork.Complete();

            return catalogBrand.Id;
        }
    }
}
