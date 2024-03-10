namespace Entities.App
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public decimal Taxes { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        public decimal? Review { get; set; }

        public int? Serving { get; set; }

        public int? Stock { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();
    }
}
