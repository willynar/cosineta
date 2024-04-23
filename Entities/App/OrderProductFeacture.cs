namespace Entities.App
{
    public class OrderProductFeacture
    {
        [Key]
        public int OrderProductFeactureOnlyId { get; set; }

        public int ProductFeactureId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal? AdditionalValue { get; set; }

        public int Stock { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        public string? ApplicationUserIdFeacture { get; set; }

        [Required, ForeignKey("OrderProductCategoryFeacture")]
        public int? OrderProductCategoryFeactureId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual OrderProductCategoryFeacture? OrderProductFeactureIdNavigation { get; set; }


    }
}
