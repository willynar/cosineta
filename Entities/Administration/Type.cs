namespace Entities.Administration
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        public string? TypeName { get; set; }

        public bool ValidForUser { get; set; }

        public virtual ICollection<Product> Products { get; } = new List<Product>();
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; } = new List<ApplicationUser>();

    }
}
