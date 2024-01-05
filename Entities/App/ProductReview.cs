namespace Entities.App
{
    public class ProductReview
    {
        [Key]
        public int IdProductReview { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int Stars { get; set; }

        public int? ProductId { get; set; }

        public virtual Product? ProductIdNavigation { get; set; }
    }
}
