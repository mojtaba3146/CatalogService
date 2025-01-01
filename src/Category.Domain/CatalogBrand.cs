using System.ComponentModel.DataAnnotations.Schema;

namespace Category.Domain
{
    public class CatalogBrand
    {
        [NotMapped]
        public const string TableName = "CatalogBrands";
        public int Id { get; set; }

        public string Brand { get; private set; } = null!;

        public static CatalogBrand Create(string brand)
        => new CatalogBrand
        {
            Brand = brand
        };

        public void Update(string brand) => Brand = brand;
    }
}
