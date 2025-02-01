using Category.Infrastructure;
using Category.Infrastructure.Test;
using Category.Service.CatalogBrands.Contracts;
using Category.Service.CatalogBrands.Contracts.Dtos;
using FluentAssertions;
using TestTools.Brands;

namespace Category.Tests.Unit
{
    public class BrandUnitTests
    {
        private readonly CatalogDbContext _dataContext;
        private readonly CatalogBrandService _sut;

        public BrandUnitTests()
        {
            _dataContext =
                new EFInMemoryDatabase()
                .CreateDataContext<CatalogDbContext>();
            _sut = BrandFactory.CreateService(_dataContext);
        }
        [Fact]
        public async Task Create_adds_brand_properly()
        {
            var dto = new CreateCatalogBrandDto("DummyBarnd");

            await _sut.Create(dto);

            _dataContext.CatalogBrands.First()
                .Brand.Should().Be(dto.Brand);

        }
    }
}