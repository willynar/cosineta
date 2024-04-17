namespace Entities.App
{
    public class ProductFeactureCategoryStoreProcedure
    {
        public int ProductFeactureCategoryId { get; set; }

        public required string Category { get; set; }

        public bool IsAdditional { get; set; }

        public bool MultipleSelection { get; set; }

        public bool Required { get; set; }

        public List<ProductFeactureStoreProcedure>? ListProductFeactures { get; set; }
    }
}
