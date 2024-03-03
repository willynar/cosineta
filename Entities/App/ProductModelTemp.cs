
//public class Product
//{
//    [Key]
//    public int ProductId { get; set; }

//    [Required, StringLength(200)]
//    public string Name { get; set; } = string.Empty;

//    public string? Description { get; set; }

//    [StringLength(200)]
//    public string? Image { get; set; }

//    public decimal Price { get; set; }

//    public string? Ingredients { get; set; }

//    public bool Active { get; set; }

//    public decimal? Review { get; set; }

//    public int? Serving { get; set; }

//    public int? Stock { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }


//    [Required, ForeignKey("ApplicationUser")]
//    public required string ApplicationUserId { get; set; }

//    [JsonIgnore]
//    public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();

//    [JsonIgnore]
//    public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

//    [JsonIgnore]
//    public virtual ICollection<ProductSchedule> ProductSchedules { get; } = new List<ProductSchedule>();
//}
//public class ProductCategory
//{
//    [Key]
//    public int ProductCategoryId { get; set; }

//    [Required, ForeignKey("Category")]

//    public int CategoryId { get; set; }

//    [Required, ForeignKey("Category")]

//    public int ProductId { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    [JsonIgnore]
//    public virtual Category? CategoryIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual Product? ProductIdNavigation { get; set; }
//}
//public class ProductFeature
//{

//    [Key]
//    public int ProductFeatureId { get; set; }

//    public required string Features { get; set; }

//    public bool MultipleSelection { get; set; }

//    public bool IsAdditional { get; set; }

//    public decimal? AdditionalValue { get; set; }

//    public bool Active { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    [Required, ForeignKey("ApplicationUser")]
//    public required string ApplicationUserId { get; set; }

//    [JsonIgnore]
//    public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

//}
//public class ProductFeaturesDetail
//{
//    [Key]
//    public int ProductFeaturesDetailId { get; set; }

//    public bool Required { get; set; }

//    [Required, ForeignKey("Product")]
//    public required int ProductId { get; set; }

//    [Required, ForeignKey("ProductFeatures")]
//    public required int ProductFeaturesId { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    [JsonIgnore]
//    public virtual Product? ProductIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual ProductFeature? ProductFeaturesIdNavigation { get; set; }
//}
//public class ProductSchedule
//{
//    [Key]
//    public int ProductScheduleId { get; set; }

//    public DateTime StarTime { get; set; }

//    public DateTime EndTime { get; set; }

//    public DateTime PublicationStarTime { get; set; }

//    public DateTime PublicationEndTime { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    public bool Active { get; set; }

//    [Required, ForeignKey("Product")]
//    public required int ProductId { get; set; }

//    [JsonIgnore]
//    public virtual Product? ProductIdNavigation { get; set; }
//}
//public class Review
//{
//    [Key]
//    public int ReviewId { get; set; }

//    public string? Title { get; set; }

//    public string? Description { get; set; }

//    public string? Author { get; set; }

//    public int Stars { get; set; }

//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    [Required, ForeignKey("Type")]
//    public required int TypeId { get; set; }


//    [ForeignKey("ApplicationUser")]
//    [Description("Parametro opcional depende del tipo si es usuario o producto")]
//    public string? ApplicationUserId { get; set; }


//    [ForeignKey("Product")]
//    [Description("Parametro opcional depende del tipo si es usuario o producto")]
//    public int? ProductId { get; set; }

//    [JsonIgnore]
//    public virtual Administration.Type? TypeIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//    [JsonIgnore]
//    public virtual Product? ProductIdNavigation { get; set; }
//}
//public DbSet<Product> Products { get; set; }
//public DbSet<Review> Reviews { get; set; }
//public DbSet<ProductSchedule> ProductSchedules { get; set; }
//public DbSet<ProductCategory> ProductCategorys { get; set; }
//public DbSet<ProductFeaturesDetail> ProductFeaturesDetails { get; set; }
//public DbSet<ProductFeature> ProductFeatures { get; set; }


