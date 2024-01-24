namespace Entities.App
{
    public class ChefReview
    {
        [Key]
        public int IdChefReview { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int Stars { get; set; }

        public int? ChefId { get; set; }

        public virtual Chef? ChefIdNavigation { get; set; }
    }
}
