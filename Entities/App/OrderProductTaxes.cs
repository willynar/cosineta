namespace Entities.App
{
    internal class OrderProductTaxes
    {
        [Key]
        public int OrderProductTaxesId { get; set; }

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
