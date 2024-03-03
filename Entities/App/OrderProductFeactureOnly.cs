namespace Entities.App
{
    public class OrderProductFeactureOnly
    {
        [Key]
        public int OrderProductFeactureOnlyId { get; set; }

        public required string Features { get; set; }

        public bool MultipleSelection { get; set; }

        public bool IsAdditional { get; set; }

        public decimal? AdditionalValue { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        public string? ApplicationUserIdFeacture { get; set; }

    }
}
