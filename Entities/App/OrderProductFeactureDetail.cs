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
        [Required, ForeignKey("OrderProduct")]
        public int? OrderProductId { get; set; }

        [JsonIgnore]
        public virtual OrderProduct? OrderProductIdNavigation { get; set; }

        //To Feacture
        [Required, ForeignKey("OrderProductFeactureOnly")]
        public int? OrderProductFeactureOnlyId { get; set; }

        [JsonIgnore]
        public virtual OrderProductFeactureOnly? OrderProductFeactureOnlyIdNavigation { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

    }
}
