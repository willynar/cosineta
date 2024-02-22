namespace Entities.App
{
    public class ProductFeaturesDetail
    {
        [Key]
        public int ProductFeaturesDetailId { get; set; }

        public bool Required { get; set; }

        [Required, ForeignKey("Product")]
        public required int ProductId { get; set; }

        [Required, ForeignKey("ProductFeatures")]
        public required int ProductFeaturesId { get; set; }

        [NotMapped]
        public virtual Product? ProductIdNavigation { get; set; }

        [NotMapped]
        public virtual ProductFeature? ProductFeaturesIdNavigation { get; set; }
    }
}
