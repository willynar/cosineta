namespace Entities.App
{
    public class ProductCategoryFeactureModel
    {
        public int? ProductFeactureCategoryId { get; set; }
        public required string Category { get; set; }

        public required List<ProductFeactureModel> ListProductFeactures { get; set; }

    }
}
