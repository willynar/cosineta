namespace Entities.App
{
    public class OrderProductFeacture
    {
        [Key]
        public int OrderProductFeactureIs { get; set; }

        public decimal Price { get; set; }

        public required string Features { get; set; }

        [Required, ForeignKey("ProductFeature")]
        public required string ProductFeatureId { get; set; }

        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }
    }
}
