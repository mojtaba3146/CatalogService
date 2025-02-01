using Category.Domain;
using Category.Domain.CommanInterfaces;
using Category.Service.CatalogBrands.Contracts;
using Category.Service.CatalogBrands.Contracts.Dtos;
using Category.Service.CatalogBrands.Exceptions;

namespace Category.Service.CatalogBrands
{
    public class CatalogBrandAppService(UnitOfWork _unitOfWork,
        CatalogBrandRepository _catalogBrandRepository) : CatalogBrandService
    {
        public async Task<int> Create(CreateCatalogBrandDto dto)
        {
            StopIfBrandIsNullOrEmpty(dto.Brand);
            StopIfBrandLenghtExceeded(dto.Brand);
            var isBrandExist = await _catalogBrandRepository.IsExist(dto.Brand);
            StopIfBrandAlreadyExist(isBrandExist);

            var catalogBrand = CatalogBrand.Create(dto.Brand);

            _catalogBrandRepository.Add(catalogBrand);

            await _unitOfWork.Complete();

            return catalogBrand.Id;
        }

        private static void StopIfBrandAlreadyExist(bool isBrandExist)
        {
            if (isBrandExist)
            {
                throw new BrandAlreadyExistException();
            }
        }

        private static void StopIfBrandLenghtExceeded(string brand)
        {
            if (brand.Length > 100)
            {
                throw new BrandLengthExceededException();
            }
        }

        private static void StopIfBrandIsNullOrEmpty(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new BrandIsNullOrEmptyException();
            }
        }
    }
}
