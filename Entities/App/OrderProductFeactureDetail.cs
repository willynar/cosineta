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

        public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();

        //To Feacture
        [ForeignKey("ProductFeature")]
        public int? ProductFeatureId { get; set; }

        public virtual Product? ProductIdNavigation { get; set; }
        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }

    }
}
