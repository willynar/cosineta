namespace Entities.App
{
    public class OrderProductCategoryFeacture
    {
        [Key]
        public int OrderProductCategoryFeactureId { get; set; }

        public string? ProductFeactureCategory { get; set; }

        public required string Description { get; set; }

        public bool Required { get; set; }

        public bool IsAdditional { get; set; }

        public bool MultipleSelection { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        [Required, ForeignKey("OrderProduct")]
        public  int? OrderProductId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual OrderProduct? OrderProductIdNavigation { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();
    }
}
