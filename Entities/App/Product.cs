namespace Entities.App
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        [Required, StringLength(50), ForeignKey("Chef")]
        public string? ChefId { get; set; }

        public decimal Price { get; set; }

        public int Serving { get; set; }

        public string? Ingredients { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public Chef? Chef { get; set; }
    }
}
