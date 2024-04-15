namespace Entities.App
{
    public class ProductFeactureModel
    {
        [Display(Description = "No requerido para guardar")]
        public int? ProductFeactureId { get; set; } = null;

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal? AdditionalValue { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; }

        public required string ApplicationUserId { get; set; }

    }
}
