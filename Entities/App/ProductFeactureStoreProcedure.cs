namespace Entities.App
{
    public class ProductFeactureStoreProcedure
    {
        public int ProductFeatureId { get; set; }

        public int ProductFeactureCategoryId { get; set; }

        public required string Name { get; set; }

        public decimal? AdditionalValue { get; set; }

        public required string ApplicationUserId { get; set; }

        public bool Active { get; set; }

    }
}
