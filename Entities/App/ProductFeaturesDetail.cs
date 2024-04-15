namespace Entities.App
{
    public class ProductFeaturesDetail
    {
        [Key]
        public int ProductFeaturesDetailId { get; set; }

        [Required, ForeignKey("Product")]
        public required int ProductId { get; set; }

        [Required, ForeignKey("ProductFeatures")]
        public required int ProductFeatureId { get; set; }

        [Required, ForeignKey("ProductFeactureCategory")]
        public required int ProductFeactureCategoryId { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        [JsonIgnore]
        public virtual Product? ProductIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ProductFeature? ProductFeaturesIdNavigation { get; set; }

        //[JsonIgnore]
        //public virtual ProductFeactureCategory? ProductFeactureCategorysIdNavigation { get; set; }
    }
}
