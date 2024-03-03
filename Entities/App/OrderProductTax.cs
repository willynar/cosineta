namespace Entities.App
{
    public class OrderProductTax
    {
        [Key]
        public int OrderProductTaxId { get; set; }

        public required decimal Taxes { get; set; }

        public required string Country { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }
    }
}
