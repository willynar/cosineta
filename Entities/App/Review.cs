namespace Entities.App
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public int Stars { get; set; }

        public DateTime Date { get; set; }

        [Required, ForeignKey("Type")]
        public required int TypeId { get; set; }


        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }


        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [NotMapped]
        public virtual Administration.Type? TypeIdNavigation { get; set; }

        [NotMapped]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [NotMapped]
        public virtual Product? ProductIdNavigation { get; set; }
    }
}
