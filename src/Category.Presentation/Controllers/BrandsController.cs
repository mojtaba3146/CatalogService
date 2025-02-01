using Category.Service.CatalogBrands.Contracts;
using Category.Service.CatalogBrands.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Category.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CatalogBrandService _service;

        public BrandsController(CatalogBrandService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add([FromBody] CreateCatalogBrandDto dto)
        {
            await _service.Create(dto);
        }
    }
}
