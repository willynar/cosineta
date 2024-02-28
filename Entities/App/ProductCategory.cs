namespace Entities.App
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required, ForeignKey("Category")]

        public int CategoryId { get; set; }

        [Required, ForeignKey("Category")]

        public int ProductId { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        [JsonIgnore]
        public virtual Category? CategoryIdNavigation { get; set; }

        [JsonIgnore]
        public virtual Product? ProductIdNavigation { get; set; }
    }
}
