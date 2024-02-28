namespace Entities.App
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        public decimal? Review { get; set; }

        public int? Serving { get; set; }

        public int? Stock { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }


        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();

        [JsonIgnore]
        public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

        [JsonIgnore]
        public virtual ICollection<ProductSchedule> ProductSchedules { get; } = new List<ProductSchedule>();
    }
}
