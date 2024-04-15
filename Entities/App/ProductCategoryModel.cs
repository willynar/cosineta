namespace Entities.App
{
    public class ProductCategoryModel
    {
        public int? CategoryId { get; set; } = null;

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Image { get; set; }

        public bool Active { get; set; }
    }
}
