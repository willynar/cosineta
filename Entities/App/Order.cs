namespace Entities.App
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public decimal TotalDelivery { get; set; }

        public decimal TotalOrder { get; set; }

        public int QuantityOfProducts { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public string? Direccion { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

    }
}
