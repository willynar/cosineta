namespace Entities.App
{
    public class ProductCategoryFeactureModel
    {
        public int? ProductFeactureCategoryId { get; set; } = null;
        public required string Category { get; set; }

        public List<ProductFeactureModel> ListProductFeactures { get; set; } = new List<ProductFeactureModel>();
    }
}
