namespace Entities.App
{
    public class ProductCategoryFeactureModel
    {
        public int? ProductFeactureCategoryId { get; set; } = null;

        public required string Description { get; set; }

        public bool Required { get; set; }

        public bool IsAdditional { get; set; }

        public bool MultipleSelection { get; set; }

        public List<ProductFeactureModel> ListDetailFeatures { get; set; } = new List<ProductFeactureModel>();
    }
}
