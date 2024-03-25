namespace Entities.App
{
    public class ProductFeactureCategory
    {
        [Key]
        public int ProductFeactureCategoryId { get; set; }

        public required string Category { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

    }
}
