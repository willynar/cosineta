namespace Entities.App
{
    public class ProductFeactureCategory
    {
        [Key]
        public int ProductFeactureCategoryId { get; set; }

        public required string Description { get; set; }

        public bool Required { get; set; }

        public bool IsAdditional { get; set; }

        public bool MultipleSelection { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        public required int ProductId { get; set; }
    }
}
