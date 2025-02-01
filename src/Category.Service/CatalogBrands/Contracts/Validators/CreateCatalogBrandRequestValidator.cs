using Category.Service.CatalogBrands.Contracts.Dtos;
using FluentValidation;

namespace Category.Service.CatalogBrands.Contracts.Validators
{
    public class CreateCatalogBrandRequestValidator : 
        AbstractValidator<CreateCatalogBrandDto>
    {
        public CreateCatalogBrandRequestValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}
