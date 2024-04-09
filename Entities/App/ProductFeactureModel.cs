namespace Entities.App
{
    public class ProductFeactureModel
    {
        [Display(Description = "No requerido para guardar")]
        public int? ProductFeatureId { get; set; } = null;

        public required string Features { get; set; }

        public bool MultipleSelection { get; set; }

        public bool IsAdditional { get; set; }

        public decimal? AdditionalValue { get; set; }

        public bool Active { get; set; }

        public required string ApplicationUserId { get; set; }

    }
}
