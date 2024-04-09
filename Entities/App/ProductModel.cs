namespace Entities.App
{
    public class ProductModel
    {
        [Display(Description = "No requerido para guardar")]
        public int? ProductId { get; set; } = null;

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        public int? Serving { get; set; }

        public int? Stock { get; set; }

        [Required, ForeignKey("Type")]
        public required int TypeId { get; set; }

        public required string ApplicationUserId { get; set; }

        public List<ProductCategoryFeactureModel> ListProductCategoryFeacture { get; set; } = new List<ProductCategoryFeactureModel>();

    }
}
