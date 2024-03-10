namespace Entities.App
{
    public class OrderProductFeacture
    {
        [Key]
        public int OrderProductFeactureId { get; set; }

        public required string Features { get; set; }

        public bool MultipleSelection { get; set; }

        public bool IsAdditional { get; set; }

        public decimal? AdditionalValue { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        [Required, ForeignKey("OrderProduct")]
        public  int? OrderProductId { get; set; }

        [JsonIgnore]
        public virtual OrderProduct? OrderProductIdNavigation { get; set; }

    }
}
