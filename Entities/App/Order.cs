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

        public decimal? Kilometers { get; set; }

        public string? Bin { get; set; }

        public string? PaymentMethod { get; set; }

        public string? PaymentStatus { get; set; }


        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

    }
}
