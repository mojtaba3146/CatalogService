using System.ComponentModel.DataAnnotations.Schema;

namespace Category.Domain
{
    public class CatalogItem
    {
        [NotMapped]
        public const string TableName = "CatalogItems";

        public int Id { get; set; }
        public string Name { get; private set; } = null!;

        public string Description { get; private set; } = null!;

        public decimal Price { get; private set; }

        public int AvailableStock { get; private set; }

        public string Slug { get; private set; } = null!;

        public int MaxStockThreshold { get; private set; }
        public ICollection<CatalogMedia> Medias { get; private set; } = null!;
    }
}
