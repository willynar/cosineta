namespace Entities.App
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public decimal TotalOrder { get; set; }

        public int QuantityOfProducts { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

    }
}
