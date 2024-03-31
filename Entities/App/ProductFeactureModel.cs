namespace Entities.App
{
    public class ProductFeactureModel
    {
        [Display(Description ="No reuqerido para guardar")]
        public int? ProductFeatureId { get; set; }

        public required string Features { get; set; }

        public bool MultipleSelection { get; set; }

        public bool IsAdditional { get; set; }

        public decimal? AdditionalValue { get; set; }

        public bool Active { get; set; }

        public required string ApplicationUserId { get; set; }

        [Display(Description = "No reuqerido para guardar")]
        public int? ProductFeactureCategoryId { get; set; }

    }
}
