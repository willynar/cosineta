namespace Entities.App
{
    public class ProductCategoryFeactureModel
    {
        public int? ProductFeactureCategoryId { get; set; }
        public required string Category { get; set; }

        public List<ProductFeactureModel> ListProductFeactures { get; set; } = new List<ProductFeactureModel>();
    }
}
