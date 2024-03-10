//public class Order
//{
//    [Key]
//    public int OrderId { get; set; }

//    public decimal TotalDelivery { get; set; }

//    public decimal TotalOrder { get; set; }

//    public int QuantityOfProducts { get; set; }

//    public string? Latitude { get; set; }

//    public string? Longitude { get; set; }

//    public string? Direccion { get; set; }

//    public decimal? Kilometers { get; set; }

//    [Required, ForeignKey("ApplicationUser")]
//    public required string ApplicationUserId { get; set; }

//    [JsonIgnore]
//    public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//    public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

//}
//public class OrderProductFeactureDetail
//{
//    [Key]
//    public int OrderProductFeactureDetailId { get; set; }

//    [Required, StringLength(200)]
//    public string Name { get; set; } = string.Empty;

//    public string? Description { get; set; }

//    [StringLength(200)]
//    public string? Image { get; set; }

//    public decimal Price { get; set; }

//    public string? Ingredients { get; set; }

//    public decimal? Review { get; set; }

//    public int? Serving { get; set; }

//    public int? Stock { get; set; }


//    [Required, ForeignKey("Order")]
//    public required int OrderId { get; set; }

//    public virtual Order? OrderIdNavigation { get; set; }

//    //To Product 
//    [Required, ForeignKey("OrderProduct")]
//    public int? OrderProductId { get; set; }

//    public virtual OrderProduct? OrderProductIdNavigation { get; set; }

//    //To Feacture
//    [Required, ForeignKey("OrderProductFeactureOnly")]
//    public int? OrderProductFeactureOnlyId { get; set; }

//    public virtual OrderProductFeactureOnly? OrderProductFeactureOnlyIdNavigation { get; set; }

//    public string? ApplicationUserIdSeller { get; set; }

//    public DateTime StarTime { get; set; }

//    public DateTime EndTime { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//}
//public class OrderProductFeacture
//{
//    [Key]
//    public int OrderProductFeactureId { get; set; }

//    public required string Features { get; set; }

//    public bool MultipleSelection { get; set; }

//    public bool IsAdditional { get; set; }

//    public decimal? AdditionalValue { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    [Required, ForeignKey("OrderProduct")]
//    public int? OrderProductId { get; set; }

//    [JsonIgnore]
//    public virtual OrderProduct? OrderProductIdNavigation { get; set; }

//}
//public class OrderProduct
//{
//    [Key]
//    public int OrderProductId { get; set; }

//    [Required, StringLength(200)]
//    public string Name { get; set; } = string.Empty;

//    public string? Description { get; set; }

//    [StringLength(200)]
//    public string? Image { get; set; }

//    public decimal Price { get; set; }

//    public decimal Taxes { get; set; }

//    public string? Ingredients { get; set; }

//    public bool Active { get; set; }

//    public decimal? Review { get; set; }

//    public int? Serving { get; set; }

//    public int? Stock { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }

//    public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();
//}
//public class OrderProductTax
//{
//    [Key]
//    public int OrderProductTaxId { get; set; }

//    public required decimal Taxes { get; set; }

//    public required string Country { get; set; }

//    public DateTime StarTime { get; set; }

//    public DateTime EndTime { get; set; }

//    [JsonIgnore]
//    public DateTime CreationDate { get; set; }

//    [JsonIgnore]
//    public DateTime UpdateDate { get; set; }
//}
//public DbSet<Order> Orders { get; set; }
//public DbSet<OrderProductFeactureDetail> OrderProductFeactureDetails { get; set; }
//public DbSet<OrderProductFeacture> OrderProductFeactures { get; set; }
//public DbSet<OrderProduct> OrderProducts { get; set; }
//public DbSet<OrderProductTax> OrderProductTaxes { get; set; }

