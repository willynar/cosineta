namespace Entities.App
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Image { get; set; }

        public bool Active { get; set; }
    }
}
