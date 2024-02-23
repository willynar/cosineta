namespace Entities.App
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public decimal TotalDelivery { get; set; }

        public decimal TotalOrder { get; set; }

        public int QuantityOfProducts { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

    }
}
