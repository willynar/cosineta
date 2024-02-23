namespace Entities.App
{
    public class OrderProductFeactureDetail
    {
        [Key]
        public int OrderProductFeactureDetailId { get; set; }

        public decimal Price { get; set; }

        [Required, ForeignKey("Order")]
        public required int OrderId { get; set; }

        public virtual Order? OrderIdNavigation { get; set; }
        
        //To Product 
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [NotMapped]
        public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();

        //To Feacture
        [ForeignKey("ProductFeature")]
        public int? ProductFeatureId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Product? ProductIdNavigation { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }

    }
}
