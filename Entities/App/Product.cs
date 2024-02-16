namespace Entities.App
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        public decimal? Review { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();
    }
}
