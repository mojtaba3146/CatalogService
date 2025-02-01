using Category.Domain;
using Category.Infrastructure;
using Category.Infrastructure.Test;
using Category.Service.CatalogBrands.Contracts;
using Category.Service.CatalogBrands.Contracts.Dtos;
using Category.Service.CatalogBrands.Exceptions;
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

        [Fact]
        public async Task Create_throw_BrandIsNullOrEmptyException_when_adds_brand()
        {
            var dto = new CreateCatalogBrandDto(" ");

            var expected = async () => await _sut.Create(dto);

            await expected.Should()
                .ThrowExactlyAsync<BrandIsNullOrEmptyException>();
        }

        [Fact]
        public async Task Create_BrandLengthExceededException_when_adds_brand()
        {
            var longString = new string('A', 101);
            var dto = new CreateCatalogBrandDto(longString);

            var expected = async () => await _sut.Create(dto);

            await expected.Should()
                .ThrowExactlyAsync<BrandLengthExceededException>();
        }

        [Fact]
        public async Task Create_BrandAlreadyExistException_when_adds_brand()
        {
            var BrandName = "DummyBrand";
            var catalogBrand = CatalogBrand.Create(BrandName);
            _dataContext.Manipulate(_ => _.CatalogBrands.Add(catalogBrand));
            var dto = new CreateCatalogBrandDto(BrandName);

            var expected = async () => await _sut.Create(dto);

            await expected.Should()
                .ThrowExactlyAsync<BrandAlreadyExistException>();
        }
    }
}