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

        public int Serving { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        public int? ChefId { get; set; }

        public int? CategoryId { get; set; }

        public decimal? Review { get; set; }

        public virtual  Category? CategoryIdNavigation { get; set; }

        public virtual  Chef? ChefIdNavigation { get; set; }
    }
}
