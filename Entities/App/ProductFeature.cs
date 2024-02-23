namespace Entities.App
{
    public class ProductFeature
    {

        [Key]
        public int ProductFeatureId { get; set; }

        public required string Features { get; set; }

        public bool MultipleSelection { get; set; }

        public bool IsAdditional { get; set; }

        public decimal? AdditionalValue { get; set; }

        public bool Active { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

    }
}
