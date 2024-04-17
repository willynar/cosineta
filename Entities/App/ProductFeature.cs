namespace Entities.App
{
    public class ProductFeature
    {

        [Key]
        public int ProductFeatureId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal? AdditionalValue { get; set; }

        public int? Stock { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

    }
}
