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

        public string? Address { get; set; }

        public decimal? Kilometers { get; set; }

        public string? Bin { get; set; }

        public string? PaymentMethod { get; set; }

        public string? PaymentStatus { get; set; }


        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    }
}
