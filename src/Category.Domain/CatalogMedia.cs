using System.ComponentModel.DataAnnotations.Schema;

namespace Category.Domain
{
    public class CatalogMedia
    {
        [NotMapped]
        public const string TableName = "CatalogMedias";
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int CatalogItemId { get; set;}
        public CatalogItem CatalogItem { get; set; } = null!;
    }
}
