namespace Entities.App
{
    public class OrderProductFeactureDetail
    {
        [Key]
        public int OrderProductFeactureDetailId { get; set; }


        [Required, ForeignKey("Order")]
        public required int OrderId { get; set; }

        public virtual Order? OrderIdNavigation { get; set; }

        //To Product 
        [Required, ForeignKey("OrderProduct")]
        public int? OrderProductId { get; set; }

        public virtual OrderProduct? OrderProductIdNavigation { get; set; }

        //To Feacture
        [Required, ForeignKey("OrderProductFeactureOnly")]
        public int? OrderProductFeactureOnlyId { get; set; }

        public virtual OrderProductFeactureOnly? OrderProductFeactureOnlyIdNavigation { get; set; }

        public string? ApplicationUserIdSeller{ get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

    }
}
